using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Models;

namespace XArbete.Web
{
    public static class Repository
    {
        public static IList<Dog> Dogs { get; set; }
        public static IList<Customer> Customers { get; set; }

        public static IList<TrainingHallBooking> TrainingHallBookings { get; set; }

        public static IList<GuestBookComment> GuestBookComments { get; set; }

        public static IList<HotelBooking> HotelBookings { get; set; }
    }
}
