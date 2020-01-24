using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XArbete.Web.Admin.ViewModels;
using XArbete.Web.DogHotel.ViewModels;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.TrainingHall.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Admin.Controllers
{
    public class AdminBookingsController : Controller
    {
        ITrainingHallService _traininghallService;
        IDogHotelService _dogHotelService;
        IMapper _mapper;

        public AdminBookingsController(ITrainingHallService traininghallService,
            IDogHotelService doghotelService, IMapper mapper)
        {
            _traininghallService = traininghallService;
            _dogHotelService = doghotelService;
            _mapper = mapper;
        }
        // GET: /<controller>/
        #region Bookings related
        public IActionResult ManageBookings()
        {
            var vm = new AdminManageBookingsViewModel();
            vm.TrainingHallBookings = _traininghallService.GetAll().Select(thb => _mapper.Map<TrainingHallBookingViewModel>(thb));
            vm.HotelBookings = _dogHotelService.GetAll().Select(hb => _mapper.Map<HotelBookingViewModel>(hb));

            var prev = vm.HotelBookings.Where(a => DateTime.Parse(a.To) < DateTime.Now).ToList();
            return View("ManageBookings", vm);
        }

        public async Task<IActionResult> DeleteHotelBooking(int id)
        {
            _dogHotelService.DeleteById(id);
            await _dogHotelService.CommitAsync();

            var vm = _dogHotelService.GetAll().Select(a => _mapper.Map<HotelBookingViewModel>(a));
            return PartialView("HotelBookings", vm);
        }

        public async Task<IActionResult> DeleteHallBooking(int id)
        {
            _traininghallService.DeleteById(id);
            await _traininghallService.CommitAsync();

            var vm = _traininghallService.GetAll().Select(a => _mapper.Map<TrainingHallBookingViewModel>(a));
            return PartialView("HallBookings", vm);
        }
        #endregion

    }
}
