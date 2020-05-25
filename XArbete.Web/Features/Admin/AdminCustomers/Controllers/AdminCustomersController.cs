using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Features.Admin.AdminCustomers.ViewModels;
using XArbete.Web.Features.Customer.ViewModels;
using XArbete.Web.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.Admin.AdminCustomers.Controllers
{
    public class AdminCustomersController : Controller
    {
        // GET: /<controller>/
        ICustomerService _customerService;
        ITrainingHallService _traininghallService;
        IDogHotelService _dogHotelService;
        IUserService _userService;
        IMailService _mailService;
        IMapper _mapper;
        IToastNotification _toastNotification;


        public AdminCustomersController(ICustomerService customerservice,
            ITrainingHallService traininghallService,
            IDogHotelService doghotelService,
            IMapper mapper,
            IMailService mailservice,
                    IToastNotification toastNotification,
                    IUserService userService
        )
        {
            _customerService = customerservice;
            _traininghallService = traininghallService;
            _dogHotelService = doghotelService;
            _userService = userService;
            _mailService = mailservice;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }
        #region Customers related
        public async Task<IActionResult> ManageCustomers()
        {
            return View("ManageCustomers", GetAdminCustomersViewModel());
        }
        public IActionResult ReloadCustomers()
        {
            var vm = GetAdminCustomersViewModel();
            return PartialView("Customers", vm);
        }

        AdminManageCustomersViewModel GetAdminCustomersViewModel()
        {
            var vm = new AdminManageCustomersViewModel();
            vm.Customers = _customerService.GetAll().Select(c => _mapper.Map<CustomerViewModel>(c));
            foreach (var cust in vm.Customers)
            {
                cust.Dogs = _mapper.Map<List<CustomerDogViewModel>>(_customerService.GetCustomerDogs(cust.ID));
            }
            return vm;
        }
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var user = await _customerService.GetSingleAsync(a => a.CustomerId == id);

            var bookingsCount = await _traininghallService.DeleteCustomerBookings(id);
            await _traininghallService.CommitAsync();

            bookingsCount += await _dogHotelService.DeleteCustomerBookings(id);
            await _dogHotelService.CommitAsync();

            var dogsCount = await _customerService.DeleteCustomerDogs(id);
            //await _customerService.CommitAsync();

            _customerService.DeleteById(id);
            await _customerService.CommitAsync();

            _userService.DeleteByUserId(user.ApplicationUserID);
            await _userService.CommitAsync();

           


            _toastNotification.AddInfoToastMessage($"Raderat kund med id {id} tillsammans med {bookingsCount} bokning(ar) och {dogsCount} hund(ar)");

            return RedirectToAction("ReloadCustomers");

        }

        public async Task<IActionResult> ConfirmPayment(int id)
        {
            //check
            var booking = await _traininghallService.GetByIdAsync(id);
            var cust = await _customerService.GetByIdAsync(booking.CustomerID);
            _traininghallService.MarkAsPayed(booking);
            await _traininghallService.CommitAsync();
            await _mailService.CreateHallCodeMail(cust, booking);

            _toastNotification.AddSuccessToastMessage($"Bokning markerad som betald, ett mejl med dörrkod skickad till bokaren.");

            return Json(new { success = true });
        }

        public async Task<IActionResult> Search(string searchValue)
        {
            var vm = new AdminManageCustomersViewModel();
            if (searchValue == null)
            {
                vm.Customers = _mapper.Map<List<CustomerViewModel>>(_customerService.GetAll());
            }
            else
            {
                var searchValueToLower = searchValue.ToLower();
                if ("admin".Contains(searchValueToLower))
                {
                    vm.Customers = _mapper.Map<List<CustomerViewModel>>(_customerService.GetMany(a => a.IsAdmin));
                }
                else
                {
                    vm.Customers = _mapper.Map<List<CustomerViewModel>>(
                                                _customerService.GetMany(a => a.Name.ToLower().Contains(searchValueToLower)
                                                    || a.Email.ToLower().Contains(searchValueToLower)
                                                    || (a.Number != null && a.Number.Contains(searchValueToLower))));
                }
               

            }
            return PartialView("Customers", vm);
        }
        #endregion

    }
}
