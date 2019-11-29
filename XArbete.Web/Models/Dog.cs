using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Web.Models
{
    public class Dog
    {
        public int ID { get; set; }

        public string Img { get; set; }
        public int CustomerID { get; set; }
        public string Name { get; set; }

        public string Sex { get; set; }

        public bool KennelDog { get; set; }

        
    }
}
