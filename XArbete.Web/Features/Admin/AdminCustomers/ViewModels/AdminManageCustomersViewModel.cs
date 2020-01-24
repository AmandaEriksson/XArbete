using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Customer.ViewModels;
using XArbete.Web.User.ViewModels;

namespace XArbete.Web.Admin.ViewModels
{
    public class AdminManageCustomersViewModel : BaseViewModel
    {
        public AdminManageCustomersViewModel()
        {
            Title = "Hantera användare";
        }
       public CustomerViewModel Customer { get; set; }
        public IEnumerable<CustomerDogViewModel> Dogs { get; set; }
       public IEnumerable<CustomerViewModel> Customers { get; set; }


        //public RegisterViewModel RegisterViewModel { get; set; }
    }
}
