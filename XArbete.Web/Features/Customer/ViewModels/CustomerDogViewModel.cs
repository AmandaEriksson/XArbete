using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Web.Customer.ViewModels
{
    public class CustomerDogViewModel
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        //public Customer Owner { get; set; }
        [Display(Name = "Hundens ras")]
        public string Ras { get; set; }

        [Display(Name = "Hundens namn")]
        public string Name { get; set; }

        [Display(Name = "Hundens födelsedatum")]
        public string DateOfBirth { get; set; }
        public string Sex { get; set; }

        [Display(Name = "Annat/allergier")]
        public string Other { get; set; }

        [Display(Name = "Kastrerad")]
        public bool Kastrated { get; set; }

        [Display(Name = "Kan bo med andra")]
        public bool CanLiveWithOtherDogs { get; set; }
    }
}
