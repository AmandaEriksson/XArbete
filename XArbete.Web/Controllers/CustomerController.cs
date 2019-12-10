using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using XArbete.Web.Models;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        private readonly IToastNotification _toastNotification;
        private readonly IDogService _dogService;
        private readonly IDogHotelService _hotelService;
        private readonly ICustomerService _customerService;
        private readonly ITrainingHallService _trainingHallService;

        public CustomerController(IToastNotification toastNotification,
            IDogService dogservice,
            IDogHotelService hotelservice,
            ICustomerService customerservice,
            ITrainingHallService traininghallservice)
        {
            _toastNotification = toastNotification;
            _dogService = dogservice;
            _hotelService = hotelservice;
            _customerService = customerservice;
            _trainingHallService = traininghallservice;
        }
        public IActionResult Index()
        {
            var model = new CustomersAdminViewModel()
            {
                Customer = _customerService.GetById(1),
                Dogs = _dogService.GetMany(a => a.ID == 1),
                HotelBookings = _hotelService.GetMany(a => a.CustomerID == 1),
                TrainingHallBookings = _trainingHallService.GetMany(a => a.CustomerID == 1)
            };
            return View(model);
        }
        public IActionResult Login(string email, string password)
        {
            return View();
        }

        public IActionResult Register(string email, string password)
        {
            return View();
        }

        public IActionResult AddDog(CustomersAdminViewModel model)
        {
            var dog = new Dog()
            {
                
                Name = model.Dog.Name,
                Owner = _customerService.GetById(1),
                Sex = model.Dog.Sex,
                Ras = model.Dog.Ras,
                Other = model.Dog.Other,
                Kastrated = model.Dog.Kastrated,
                CanLiveWithOtherDogs = model.Dog.CanLiveWithOtherDogs
            };
            _dogService.Create(dog);

            _toastNotification.AddSuccessToastMessage($"Hund {dog.Name} sparad.");

            return RedirectToAction("Index");
        }

        public IActionResult UpdateInfo(CustomersAdminViewModel model)
        {
            //var customer = _customerService.GetById(model.Customer.ID);
            _customerService.Update(model.Customer);
            //customer.Name = model.Customer.Name;
            //customer.Number = model.Customer.Number;

            _toastNotification.AddSuccessToastMessage($"Dina nya uppgifter är sparade.");

            return RedirectToAction("Index");
        }

        public IActionResult RemoveDog(int id)
        {
            var connectedBookings = _hotelService.GetMany(a => a.Dog.ID == id && a.From >= DateTime.Now);


            if (connectedBookings.Count() != 0)
            {
                if (connectedBookings.Any(f => f.From < DateTime.Now.AddHours(24) && f.From > DateTime.Now))
                {
                    _toastNotification.AddErrorToastMessage($"Kunde inte radera hunden. Det finns en bokning inom 24 timmar kopplad till hunden.");
                    return RedirectToAction("Index");
                }

                int counter = 0;
                foreach (var booking in connectedBookings)
                {
                    _hotelService.Delete(booking);
                    counter++;
                }
                _toastNotification.AddSuccessToastMessage($"Hunden raderad tillsammans med {counter} pensionat bokning(ar) kopplad till hunden.");
            }
            else
            {
                _toastNotification.AddSuccessToastMessage($"Hunden raderad.");
            }
            _dogService.Delete(_dogService.GetById(id));
            return RedirectToAction("Index");
        }
    }
}
