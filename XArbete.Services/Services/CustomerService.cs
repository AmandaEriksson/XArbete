using XArbete.Domain.Models;
using XArbete.Services.Data;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        public CustomerService(XArbeteContext context,
            IUserService userservice) : base(context)
        {
        }

       
    }
}
