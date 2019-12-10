using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Models;

namespace XArbete.Web.ViewModels
{
    public class AdminManageCustomersViewModel
    {
       public Customer Customer { get; set; }

       public IEnumerable<Customer> Customers { get; set; }
    }
}
