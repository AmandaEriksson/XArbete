using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Domain.Models
{
    public class KennelDog
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Img { get; set; }

        public string Sex { get; set; }

        public string About { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }
    }
}
