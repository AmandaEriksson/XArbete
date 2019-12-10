using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using XArbete.Web.Models;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.Utils.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Controllers
{
    public class DogHotelController : Controller
    {
        // GET: /<controller>/
        private readonly IToastNotification _toastNotification;
        private readonly IMailService _mailService;
        private readonly IDogHotelService _bookingService;
        private readonly IDogService _dogService;

        public DogHotelController(IToastNotification toastNotification,
            IMailService mailService, 
            IDogHotelService bookingService,
            IDogService dogService)
        {
            _toastNotification = toastNotification;
            this._mailService = mailService;
            _bookingService = bookingService;
            _dogService = dogService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Book()
        {
            return View("Book");
        }
        public IActionResult PriceInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewBooking(HotelBooking booking)
        {
            var dog = _dogService.GetById(booking.Dog.ID);
            //hämta inloggad kund
            var customer = Repository.Customers.SingleOrDefault(a => a.ID == 1);

            var book = new HotelBooking()
            {
                //hårdkodat
                ID = Repository.HotelBookings.Max(a => a.ID) + 1,
                Customer = customer,
                Dog = dog,
                From = booking.From,
                To = booking.To,
                CustomerMessage = booking.CustomerMessage,
                Price = PriceCalculationService.HotelPriceCalculation(booking),
                ExtraWalk = booking.ExtraWalk,
                Training = booking.Training,
                Grooming = booking.Grooming
            };

            // service.create(book)
            _bookingService.Create(book);
            //Repository.HotelBookings.Add(book);

            _mailService.CreatePdfContent(book);

            _mailService.SendHotelMail(customer, book);

            _toastNotification.AddSuccessToastMessage($"Tack för din bokning! Kolla din mejl för info om din bokning och betalning.");


            return RedirectToAction("Book");
        }

        public IActionResult DeleteBooking(int id)
        {
            var booking = _bookingService.GetById(id);
            if (booking.From < DateTime.Now.AddHours(24))
            {
                _toastNotification.AddErrorToastMessage($"Din bokning är mindre än 24 timmar framåt, det går ej att avboka.");

            }
            else
            {
                _bookingService.Delete(booking);
                _toastNotification.AddSuccessToastMessage($"Din bokning är avbokad.");

            }

            return RedirectToAction("Index", "Customer");
        }
    }
}
