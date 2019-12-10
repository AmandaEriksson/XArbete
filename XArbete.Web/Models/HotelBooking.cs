using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XArbete.Web.Models
{
    public class HotelBooking
    {
        public int ID { get; set; }
 
        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public string CustomerMessage { get; set; }

        public double Price { get; set; }

        public bool Grooming { get; set; }

        public bool Training { get; set; }

        public bool ExtraWalk { get; set; }

        public int DogID { get; set; }
        public Dog Dog { get; set; }


        public int CustomerID { get; set; }
        public Customer Customer { get; set; }



    }
}
