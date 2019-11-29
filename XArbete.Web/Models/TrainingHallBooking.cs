using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Web.Models
{
    public class TrainingHallBooking
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Payed { get; set; }


    }
}
