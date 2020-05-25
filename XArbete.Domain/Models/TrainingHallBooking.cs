using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XArbete.Domain.Models
{
    public class TrainingHallBooking
    {
        public int TrainingHallBookingId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }


        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Payed { get; set; }

        public double Price { get; set; }
    }
}
