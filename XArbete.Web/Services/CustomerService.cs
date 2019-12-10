using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Web.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        public CustomerService(XArbeteContext context) : base(context)
        {
        }

        //public override Customer GetById(int id)
        //{
        //    return Repository.Customers.SingleOrDefault(a => a.ID == id);
        //}
   
    }
}
