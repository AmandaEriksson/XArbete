using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Web.TrainingHall.Models
{
    public class Event
    {
        public string ID { get; set; }
        public string Title { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public bool allDay { get; set; }
    }
}
