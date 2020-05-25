using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XArbete.Web.Features.Admin.AdminBookings.ViewModels;
using XArbete.Web.Features.DogHotel.ViewModels;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.Features.TrainingHall.ViewModels;
using XArbete.Web.Features.Customer.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.Admin.AdminBookings.Controllers
{
    public class AdminBookingsController : Controller
    {
        ITrainingHallService _traininghallService;
        IDogHotelService _dogHotelService;
        IMapper _mapper;
        ICustomerDogService _customerDogService;

        public AdminBookingsController(ITrainingHallService traininghallService,
            IDogHotelService doghotelService, IMapper mapper, ICustomerDogService customerdogservice)
        {
            _traininghallService = traininghallService;
            _dogHotelService = doghotelService;
            _mapper = mapper;
            _customerDogService = customerdogservice;
        }
        // GET: /<controller>/
        #region Bookings related
        public IActionResult ManageBookings()
        {
            var vm = new AdminManageBookingsViewModel();
            vm.TrainingHallBookings = _traininghallService.GetAll().Select(thb => _mapper.Map<TrainingHallBookingViewModel>(thb));
            vm.HotelBookings = _mapper.Map<List<HotelBookingViewModel>>(_dogHotelService.GetAll());
            foreach (var booking in vm.HotelBookings)
            {
                booking.Dog = _mapper.Map<CustomerDogViewModel>(_customerDogService.GetSingle(a => a.CustomerDogId == booking.DogID));
            }
            //var prev = vm.HotelBookings.Where(a => DateTime.Parse(a.To) < DateTime.Now).ToList();
            return View("ManageBookings", vm);
        }

        public async Task<IActionResult> DeleteHotelBooking(int id)
        {
            _dogHotelService.DeleteById(id);
            await _dogHotelService.CommitAsync();

            var vm = _dogHotelService.GetMany(a => a.To >= DateTime.Now).Select(a => _mapper.Map<HotelBookingViewModel>(a));
            return PartialView("HotelBookings", vm);
        }

        public async Task<IActionResult> DeleteHallBooking(int id)
        {
            _traininghallService.DeleteById(id);
            await _traininghallService.CommitAsync();

            var vm = _traininghallService.GetMany(a => a.EndTime >= DateTime.Now).Select(a => _mapper.Map<TrainingHallBookingViewModel>(a));
            return PartialView("HallBookings", vm);
        }


        #endregion

    }
}
