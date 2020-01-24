using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Domain.Models;
using XArbete.Web.Customer.ViewModels;
using XArbete.Web.DogHotel.ViewModels;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.TrainingHall.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Customer.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        private readonly IToastNotification _toastNotification;
        private readonly IDogService _dogService;
        private readonly IDogHotelService _hotelService;
        private readonly ICustomerService _customerService;
        private readonly ITrainingHallService _trainingHallService;
        private readonly IUserService _userService;
        readonly IMapper _mapper;


        public CustomerController(IToastNotification toastNotification,
            IDogService dogservice,
            IDogHotelService hotelservice,
            ICustomerService customerservice,
            ITrainingHallService traininghallservice,
             IUserService userservice,
             IMapper mapper
)
        {
            _toastNotification = toastNotification;
            _dogService = dogservice;
            _hotelService = hotelservice;
            _customerService = customerservice;
            _trainingHallService = traininghallservice;
            _userService = userservice;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _customerService.GetSingleAsync(a => a.Email == User.Identity.Name);
            var hotelbookings = _hotelService.GetMany(a => a.CustomerID == user.ID);
            var trainingHallBookings = _trainingHallService.GetMany(a => a.CustomerID == user.ID);
            var dogs = _dogService.GetMany(a => a.CustomerID == user.ID);

            var vm = new CustomersAdminViewModel();
            vm.HotelBookings = hotelbookings.Select(a => _mapper.Map<HotelBookingViewModel>(a));
            vm.TrainingHallBookings = trainingHallBookings.Select(a => _mapper.Map<TrainingHallBookingViewModel>(a));
            vm.Dogs = dogs.Select(a => _mapper.Map<CustomerDogViewModel>(a));
            vm.Customer = _mapper.Map<CustomerViewModel>(user);

            return View(vm);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewCustomerDog(CustomerDogViewModel model)
        {
            model.CustomerID = _customerService.GetSingleAsync(a => a.Email == User.Identity.Name).Result.ID;
            var dog = _mapper.Map<Dog>(model);
             _dogService.Create(dog);
             await _dogService.CommitAsync();

            return RedirectToAction("CustomerDogs", new { id = model.CustomerID });
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(CustomersAdminViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }
                var cust = await _customerService.GetSingleAsync(a => a.ID == model.Customer.ID);

                cust.Name = model.Customer.Name;
                cust.Number = model.Customer.Number;
                await _customerService.CommitAsync();

                if (model.Password != null)
                {
                    var result = await _userService.UpdatePassword(cust.ApplicationUserID, model.Password);
                    if (result)
                    {
                        _toastNotification.AddSuccessToastMessage("Ditt lösenord är ändrat och dina uppgifter sparade.");
                    }
                    else
                    {
                        _toastNotification.AddErrorToastMessage("Något gick fel.");

                    }
                }
                else
                {
                    _toastNotification.AddSuccessToastMessage($"Dina nya uppgifter är sparade.");
                }


            return PartialView(model);

        }

        public async Task<IActionResult> DeleteCustomerDog(int id)
        {
            if (!await CheckConnectedBookings(id))
            {
                return RedirectToAction("Index");
            }
            var dog = await _dogService.GetByIdAsync(id);
            _dogService.Delete(dog);
            await _dogService.CommitAsync();
            return RedirectToAction("CustomerDogs", new { id = dog.CustomerID});
        }
        public IActionResult CustomerDogs(int id)
        {
            var dogs = _dogService.GetMany(a => a.CustomerID == id);
            var model = dogs.Select(d => _mapper.Map<CustomerDogViewModel>(d));
            return PartialView(model.ToList());
        }

        private async Task<bool> CheckConnectedBookings(int id)
        {
            var connectedBookings = _hotelService.GetMany(a => a.DogID == id && a.From >= DateTime.Now);

            if (connectedBookings.Count() != 0)
            {
                if (connectedBookings.Any(f => f.From < DateTime.Now.AddHours(24) && f.From > DateTime.Now))
                {
                    _toastNotification.AddErrorToastMessage($"Kunde inte radera hunden. Det finns en bokning inom 24 timmar kopplad till hunden.");
                    return false;
                }

                int counter = 0;
                foreach (var booking in connectedBookings)
                {
                    _hotelService.Delete(booking);
                    counter++;
                }
                await _hotelService.CommitAsync();
                _toastNotification.AddInfoToastMessage($"Hunden raderad tillsammans med {counter} pensionat bokning(ar) kopplad till hunden.");
            }
            return true;

        }
    }
}
