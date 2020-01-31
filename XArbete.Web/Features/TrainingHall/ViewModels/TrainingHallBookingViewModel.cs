using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Features.User.ViewModels;

namespace XArbete.Web.Features.TrainingHall.ViewModels
{
    public class TrainingHallBookingViewModel : BaseViewModel
    {

        public int ID { get; set; }

        public int CustomerID { get; set; }
        //public Customer Customer { get; set; }

            [Display(Name = "Starttid")]
        public string StartTime { get; set; }

        [Display(Name = "Sluttid")]
        public string EndTime { get; set; }

        public bool Payed { get; set; }

        public double Price { get; set; }
    }
}
