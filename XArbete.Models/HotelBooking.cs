using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Models
{
    class HotelBooking
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public int DogID { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
