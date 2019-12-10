using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NToastNotify;
using XArbete.Web.Models;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.Utils.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Controllers
{
    public class TrainingHallController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly IMailService _mailService;
        private readonly ITrainingHallService _trainingHallService;
        private readonly ICustomerService _customerService;

        public TrainingHallController(IToastNotification toastNotification,
            IMailService mailservice,
            ITrainingHallService traininghallService,
            ICustomerService customerService)
        {
            _toastNotification = toastNotification;
            _mailService = mailservice;
            _trainingHallService = traininghallService;
            _customerService = customerService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult PriceInfo()
        {
            return View();
        }

     
        public IActionResult Book()
        {
            return View();

        }

        public IActionResult GetEvents()
        {
            var events = new List<Event>();
            var db_events = _trainingHallService.GetAll();
            //HÅRDKODAT
            var customer = _customerService.GetById(1);
            foreach (var e in db_events)
            {
                var calEvent = new Event
                {
                    ID = 1.ToString(),
                    Title = customer.Name,
                    Start = e.StartTime.ToString(),
                    End = e.EndTime.ToString()
                };
                events.Add(calEvent);
            }

            var rows = events.ToArray();

            return Json(rows);
        }


        public IActionResult NewBooking(string start, string end, bool allday)
        {
            if (allday)
            {
                start += " 06:00:00";
                end += " 22:00:00";
            }
            else
            {
                 start = start.Remove(start.IndexOf(' '));
                 end = end.Remove(end.IndexOf(' '));
            }
            var startTime = DateTime.Parse(start);
            var endTime = DateTime.Parse(end);
            var Customer = _customerService.GetById(1);
            // ta inloggad användare

            var booking = new TrainingHallBooking()
            {
                CustomerID = Customer.ID,
                StartTime = startTime,
                EndTime = endTime,
                Payed = false,
                Price = PriceCalculationService.TrainingHallPriceCalculation(startTime, endTime, allday)

            };
            _trainingHallService.Create(booking);
            _mailService.SendHallMail(Customer, booking);

            _toastNotification.AddSuccessToastMessage($"Tack för din bokning! Kolla din mejl för info om din bokning och betalning.");

            return RedirectToAction("Book");
        }
   
        public IActionResult DeleteBooking(int id)
        {
            var booking = _trainingHallService.GetById(id);
            if (booking.StartTime < DateTime.Now.AddHours(24) && booking.StartTime > DateTime.Now)
            {
                _toastNotification.AddErrorToastMessage($"Din bokning är mindre än 24 timmar framåt, det går ej att avboka.");

            }
            else
            {
                _trainingHallService.Delete(booking);
                _toastNotification.AddSuccessToastMessage($"Din bokning är avbokad.");
            }

            return RedirectToAction("Index", "Customer");
        }
    }
}
