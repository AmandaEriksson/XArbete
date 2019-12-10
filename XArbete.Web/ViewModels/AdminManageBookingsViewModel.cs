using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Models;

namespace XArbete.Web.ViewModels
{
    public class AdminManageBookingsViewModel
    {
        public IEnumerable<TrainingHallBooking> TrainingHallBookings { get; set; }

        public IEnumerable<HotelBooking> HotelBookings { get; set; }
    }
}
