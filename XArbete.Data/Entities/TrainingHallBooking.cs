using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Data.Entities
{
    class TrainingHallBooking
    {
        public Customer Booker { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Payed { get; set; }
    }
}
