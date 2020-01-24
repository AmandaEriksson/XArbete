using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Domain.Models
{
    public class KennelContent
    {
        public int ID { get; set; }

        public bool IsBreed { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public string LinkDescription { get; set; }

        public string Img { get; set; }
    }
}
