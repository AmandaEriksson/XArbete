using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Models
{
    class TrainingHallBooking
    {
        public int ID { get; set; }

        public Customer CustomerID { get; set; }
        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Payed { get; set; }

        public bool CanLiveWithOtherDogs { get; set; }

        public string CustomerMessage { get; set; }

    }
}
