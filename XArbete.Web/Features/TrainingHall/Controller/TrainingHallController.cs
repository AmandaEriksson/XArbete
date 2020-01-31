using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Domain.Models;
using XArbete.Services.Utils.Constants;
using XArbete.Services.Utils.Services;
using XArbete.Web.Features.Admin.AdminContent.ViewModels;
using XArbete.Web.Features.TrainingHall.ViewModels;
using XArbete.Web.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.TrainingHall.Controllers
{
    public class TrainingHallController : Controller
    {
        readonly IToastNotification _toastNotification;
        readonly IMailService _mailService;
        readonly ITrainingHallService _trainingHallService;
        readonly ICustomerService _customerService;
        readonly IUserService _userService;
        readonly IMapper _mapper;
        readonly IContentService _contentService;


        public TrainingHallController(IToastNotification toastNotification,
            IMailService mailservice,
            ITrainingHallService traininghallService,
            ICustomerService customerService,
            IUserService userservice,
            IMapper mapper,
            IContentService contentservice
            )
        {
            _toastNotification = toastNotification;
            _mailService = mailservice;
            _trainingHallService = traininghallService;
            _customerService = customerService;
            _userService = userservice;
            _mapper = mapper;
            _contentService = contentservice;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = _mapper.Map<ContentViewModel>(_contentService.GetSingle(a => a.Type == ContentConstants.HallAbout));
            model.Section = _mapper.Map<List<ContentSectionViewModel>>(_contentService.GetSections(model.Id));
            return View(model);
        }

        public IActionResult PriceInfo()
        {
            var model = new TrainingHallContentViewModel();
            model.PriceInfo = _mapper.Map<ContentViewModel>(_contentService.GetSingle(a => a.Type == ContentConstants.HallPriceContent));
            model.PriceInfo.Section = _mapper.Map<List<ContentSectionViewModel>>(_contentService.GetSections(model.PriceInfo.Id));
            model.ComfortRules = _mapper.Map<ContentViewModel>(_contentService.GetSingle(a => a.Type == ContentConstants.HallRulesContent));
            model.ComfortRules.Section = _mapper.Map<List<ContentSectionViewModel>>(_contentService.GetSections(model.ComfortRules.Id));

            return View(model);
        }


        public IActionResult Book()
        {
            return View();

        }

        public IActionResult GetEvents()
        {
            var events = new List<Event>();
            var trainingHallBookings = _trainingHallService.GetAll();
            foreach (var booking in trainingHallBookings)
            {
                var calEvent = new Event
                {
                    ID = booking.ID.ToString(),
                    Title = _customerService.GetById(booking.CustomerID).Name,
                    Start = booking.StartTime.ToString(),
                    End = booking.EndTime.ToString()
                };
                events.Add(calEvent);
            }

            var rows = events.ToArray();

            return Json(rows);
        }

        public async Task<IActionResult> NewBooking(string start, string end, bool allday)
        {
            if (!await _userService.IsSignedIn(User))
            {
                _toastNotification.AddErrorToastMessage("Du måste vara inloggad för att boka. Logga in eller registrera ett konto först.");
                return RedirectToAction("Book");
            }

            if (allday)
            {
                end = start + " 22:00:00";
                start += " 06:00:00";
            }
            else
            {
                start = start.Remove(start.IndexOf(' '));
                end = end.Remove(end.IndexOf(' '));
            }
            var startTime = DateTime.Parse(start);
            var endTime = DateTime.Parse(end);

            if (startTime < DateTime.Now)
            {
                _toastNotification.AddErrorToastMessage("Du kan självklart inte boka bakåt i tiden, vad är meningen med det?");
                return RedirectToAction("Book");
            }
            var Customer = await _customerService.GetSingleAsync(a => a.Email == User.Identity.Name);

            var booking = new TrainingHallBooking()
            {
                CustomerID = Customer.ID,
                StartTime = startTime,
                EndTime = endTime,
                Payed = false,
                Price = PriceCalculationService.TrainingHallPriceCalculation(startTime, endTime, allday)
            };
            _trainingHallService.Create(booking);
            await _trainingHallService.CommitAsync();
            await _mailService.SendHallMail(Customer, booking);

            _toastNotification.AddSuccessToastMessage($"Tack för din bokning! Kolla din mejl för info om din bokning och betalning.");

            return RedirectToAction("Book");
        }

        public async Task<IActionResult> DeleteHallBooking(int id)
        {
            var booking = await _trainingHallService.GetByIdAsync(id);
            var customerId = booking.CustomerID;
            if (booking.StartTime < DateTime.Now.AddHours(24) && booking.StartTime > DateTime.Now)
            {
                _toastNotification.AddErrorToastMessage($"Din bokning är mindre än 24 timmar framåt, det går ej att avboka.");

            }
            else
            {
                _trainingHallService.Delete(booking);
                await _trainingHallService.CommitAsync();
                _toastNotification.AddSuccessToastMessage($"Din bokning är avbokad.");
            }
            var bookings = _trainingHallService.GetMany(a => a.CustomerID == customerId && a.EndTime >= DateTime.Now);
            var vm = bookings.Select(b => _mapper.Map<TrainingHallBookingViewModel>(b));
            return PartialView("Customer/Views/PartialViews/CustomerHallBookings", vm.ToList());
        }
    }
}
