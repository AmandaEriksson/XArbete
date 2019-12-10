using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Web.Models
{
    public class Dog
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }
        public Customer Owner { get; set; }

        public string Ras { get; set; }
        public string Name { get; set; }

        public string Sex { get; set; }

        public string Other { get; set; }

        public bool Kastrated { get; set; }

        public bool CanLiveWithOtherDogs { get; set; }


    }
}
