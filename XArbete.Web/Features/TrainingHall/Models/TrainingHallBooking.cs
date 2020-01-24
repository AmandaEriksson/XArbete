using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Web.TrainingHall.Models
{
    public class TrainingHallBooking
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }
        public XArbete.Web.Customer.Models.Customer Customer { get; set; }


        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Payed { get; set; }

        public double Price { get; set; }
    }
}
