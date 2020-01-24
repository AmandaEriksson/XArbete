using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Customer.Models;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.Utils.Constants;

namespace XArbete.Web.Services
{
    public class CustomerService : ServiceBase<XArbete.Web.Customer.Models.Customer>, ICustomerService
    {
        public CustomerService(XArbeteContext context,
            IUserService userservice) : base(context)
        {
        }

       
    }
}
