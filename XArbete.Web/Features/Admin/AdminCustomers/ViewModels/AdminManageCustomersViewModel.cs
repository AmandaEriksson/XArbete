using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Features.Customer.ViewModels;
using XArbete.Web.Features.User.ViewModels;

namespace XArbete.Web.Features.Admin.AdminCustomers.ViewModels
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
