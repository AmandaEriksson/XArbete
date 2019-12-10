using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using XArbete.Web.Data;
using XArbete.Web.Models;
using XArbete.Web.Services;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly IMailService _mailService;
        private readonly ICustomerService _customerService;
        private readonly ITrainingHallService _trainingHallService;
        private readonly IDogHotelService _hotelService;
        private XArbeteContext _dbcontext;
     
        public AdminController( IToastNotification toastNotification,
            IMailService mailservice,
            ICustomerService customerService,
            ITrainingHallService traininghallService,
            IDogHotelService hotelService,
            XArbeteContext context
            )
        {
            _toastNotification = toastNotification;
            _mailService = mailservice;
            _customerService = customerService;
            _trainingHallService = traininghallService;
            _hotelService = hotelService;
            _dbcontext = context;
        }
        // GET: /<controller>/
        public IActionResult ManageCustomers()
        {
            var model = new AdminManageCustomersViewModel()
            {
                Customers = _customerService.GetAll()
            };
            return View(model);
        }
        public IActionResult ManageBookings()
        {
            var model = new AdminManageBookingsViewModel()
            {
                TrainingHallBookings = _trainingHallService.GetAll(),
                HotelBookings = _hotelService.GetAll()
            };
            return View(model);
        }

        public IActionResult DeleteHotelBooking(int id)
        {
            _hotelService.Delete(_hotelService.GetById(id));
            _toastNotification.AddSuccessToastMessage($"Raderat hundpensionat bokning med ID {id}");
            return View("ManageBookings");

        }

        public IActionResult DeleteHallBooking(int id)
        {
            _trainingHallService.Delete(_trainingHallService.GetById(id));
            _toastNotification.AddSuccessToastMessage($"Raderat träningshall bokning med ID {id}");
            return View("ManageBookings");
        }
        public IActionResult DeleteCustomer(int id)
        {
            _customerService.Delete(_customerService.GetById(id));
            _toastNotification.AddSuccessToastMessage($"Raderat kund med id {id}");
            return RedirectToAction("ManageCustomers");
        }

        public IActionResult NewCustomer(AdminManageCustomersViewModel model)
        {
            _customerService.Create(model.Customer);
            _toastNotification.AddSuccessToastMessage($"Ny kund skapad.");
            return RedirectToAction("ManageCustomers");
        }

        public IActionResult ConfirmPayment (int id)
        {
            var booking = _trainingHallService.GetById(id);
            var cust = _customerService.GetById(booking.CustomerID);
            _trainingHallService.MarkAsPayed(booking);

            _mailService.CreateHallCodeMail(cust, booking);

            _toastNotification.AddSuccessToastMessage($"Bokning markerad som betald, ett mejl med dörrkod skickad till bokaren.");
            return RedirectToAction("ManageBookings");
        }
    }
}
