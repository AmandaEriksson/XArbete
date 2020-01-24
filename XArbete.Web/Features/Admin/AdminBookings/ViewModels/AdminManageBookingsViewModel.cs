using System.Collections.Generic;
using XArbete.Web.DogHotel.ViewModels;
using XArbete.Web.TrainingHall.ViewModels;
using XArbete.Web.User.ViewModels;

namespace XArbete.Web.Admin.ViewModels
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
