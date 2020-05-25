using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Domain.Models
{
    public class Puppy
    {
        public int PuppyId { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public bool Sold { get; set; }

        [ForeignKey("PuppyGroup")]
        public int PuppyGroupId { get; set; }

        public string Img { get; set; }
    }
}
