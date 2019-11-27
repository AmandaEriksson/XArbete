using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Data.Entities
{
    class DogHotelBooking
    {
        public Customer Booker { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool CanStayWithOtherDogs { get; set; }

        public string OtherInfo { get; set; }
    }
}
