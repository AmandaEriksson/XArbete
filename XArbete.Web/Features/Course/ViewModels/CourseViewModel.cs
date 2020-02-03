using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Features.Customer.ViewModels;

namespace XArbete.Web.Features.Course.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Kursens namn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Display(Name = "Datum kursen startar")]
        public DateTimeOffset DatePicker { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Kostnad")]
        public int Price { get; set; }

        [Display(Name = "Antal timmar per gång")]
        public int DurationPerTime { get; set; }

        [Display(Name = "Antal veckor")]
        public int RepeatingForWeeks { get; set; }

        [Display(Name = "Platser lediga")]
        public int NumberAvailable { get; set; }

        [Display(Name = "Max antal deltagare")]
        public int MaximumParticipants { get; set; }

        public List<CustomerViewModel> Participants { get; set; }
    }
}
