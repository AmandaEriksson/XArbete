using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Domain.Models;
using XArbete.Services.Utils.Services;
using XArbete.Web.Features.Customer.ViewModels;
using XArbete.Web.Features.DogHotel.ViewModels;
using XArbete.Web.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.DogHotel.Controllers
{
    public class DogHotelController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly IMailService _mailService;
        private readonly IDogHotelService _bookingService;
        private readonly IDogService _dogService;
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public DogHotelController(IToastNotification toastNotification,
            IMailService mailService, 
            IDogHotelService bookingService,
            IDogService dogService,
            ICustomerService customerService,
            IUserService userservice,
            IMapper mapper)
        {
            _toastNotification = toastNotification;
            this._mailService = mailService;
            _bookingService = bookingService;
            _dogService = dogService;
            _customerService = customerService;
            _userService = userservice;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Book()
        {
            var model = new HotelBookingViewModel();
            if (await _userService.IsSignedIn(User))
            {
                var cust = await _customerService.GetSingleAsync(a => a.Email == User.Identity.Name);
                model.Dogs = _dogService.GetMany(a => a.CustomerID == cust.ID).Select(a => _mapper.Map<CustomerDogViewModel>(a));
            }

            return View(model);
        }
        public IActionResult PriceInfo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewBooking(HotelBookingViewModel booking)
        {
            var dog = _dogService.GetById(booking.DogID);
            var customer = _customerService.GetSingleAsync(a => a.Email == User.Identity.Name).Result;
            var book = _mapper.Map<HotelBooking>(booking);
            book.CustomerID = customer.ID;
            book.Price = PriceCalculationService.HotelPriceCalculation(book);
            _bookingService.Create(book);
            await _bookingService.CommitAsync();
            await _mailService.CreatePdfContent(book);
            await _mailService.SendHotelMail(customer, book);
            _toastNotification.AddSuccessToastMessage($"Tack för din bokning! Kolla din mejl för info om din bokning och betalning.");


            return RedirectToAction("Book");
        }

        public async Task<IActionResult> DeleteHotelBooking(int id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            var customerId = booking.CustomerID;
            if (booking.From < DateTime.Now.AddHours(24))
            {
                _toastNotification.AddErrorToastMessage($"Din bokning är mindre än 24 timmar framåt, det går ej att avboka.");
            }
            else
            {
                _bookingService.Delete(booking);
                await _bookingService.CommitAsync();
                _toastNotification.AddSuccessToastMessage($"Din bokning är avbokad.");
            }
            
            var bookings = _bookingService.GetMany(a => a.CustomerID == customerId && a.To >= DateTime.Now);
            var vm = bookings.Select(b => _mapper.Map<HotelBookingViewModel>(b));
            return PartialView("Customer/Views/PartialViews/CustomerHotelBookings", vm.ToList());
        }
    }
}
