using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Web.Models
{
    public class HotelBooking
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public int DogID { get; set; }
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool CanLiveWithOtherDogs { get; set; }

        public string CustomerMessage { get; set; }
    }
}
