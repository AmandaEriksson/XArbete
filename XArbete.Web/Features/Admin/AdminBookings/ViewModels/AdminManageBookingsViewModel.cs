using System.Collections.Generic;
using XArbete.Web.Features.Customer.ViewModels;
using XArbete.Web.Features.DogHotel.ViewModels;
using XArbete.Web.Features.TrainingHall.ViewModels;
using XArbete.Web.Features.User.ViewModels;

namespace XArbete.Web.Features.Admin.AdminBookings.ViewModels
{
    public class AdminManageBookingsViewModel : BaseViewModel
    {
        public AdminManageBookingsViewModel()
        {
            Title = "Hantera hundpensionat bokningar";
            TitleTwo = "Hantera träningshall bokningar";
        }
        public IEnumerable<TrainingHallBookingViewModel> TrainingHallBookings { get; set; }

        public string TitleTwo { get; set; }

        public IEnumerable<HotelBookingViewModel> HotelBookings { get; set; }
    }
}
