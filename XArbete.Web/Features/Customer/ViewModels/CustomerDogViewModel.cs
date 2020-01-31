using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Web.Features.Customer.ViewModels
{
    public class CustomerDogViewModel
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        //public Customer Owner { get; set; }
        [Display(Name = "Ras")]
        public string Breed { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "Födelsedatum")]
        public DateTimeOffset DateOfBirthOffset { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Kön")]
        public string Sex { get; set; }


        [Display(Name = "Kastrerad")]
        public bool Kastrated { get; set; }

    }
}
