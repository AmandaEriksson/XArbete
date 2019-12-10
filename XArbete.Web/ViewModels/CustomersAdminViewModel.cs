using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Models;

namespace XArbete.Web.ViewModels
{
    public class CustomersAdminViewModel
    {
        public Customer Customer { get; set; }

        public Dog Dog { get; set; }

        public IEnumerable<Dog> Dogs { get; set; }

        public IEnumerable<HotelBooking> HotelBookings { get; set; }

        public IEnumerable<TrainingHallBooking> TrainingHallBookings { get; set; }
    }
}
