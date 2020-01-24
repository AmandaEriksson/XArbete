using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Web.Customer.ViewModels
{
    public class CustomerViewModel
    {
        public int ID { get; set; }

        public string ApplicationUserID { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefonnummer")]
        public string Number { get; set; }

        public bool IsAdmin { get; set; }

    }
}
