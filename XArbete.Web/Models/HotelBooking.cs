using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XArbete.Web.Models
{
    public class HotelBooking
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public int DogID { get; set; }
        public string From { get; set; }

        public string To { get; set; }

        public bool CanLiveWithOtherDogs { get; set; }

        public string CustomerMessage { get; set; }

    }
}
