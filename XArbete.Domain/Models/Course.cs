using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Domain.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int Price { get; set; }

        public int DurationPerTime { get; set; }

        public int RepeatingForWeeks { get; set; }

        public int NumberAvailable { get; set; }

        public int MaximumParticipants { get; set; }
    }
}
