using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XArbete.Domain.Models
{
    public class HotelBooking
    {
        public int HotelBookingId { get; set; }
 
        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public string CustomerMessage { get; set; }

        public double Price { get; set; }

        public bool Grooming { get; set; }

        public bool Training { get; set; }

        public bool ExtraWalk { get; set; }

        public bool CanLiveWithOtherDogs { get;set; }
        public int DogID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }



    }
}
