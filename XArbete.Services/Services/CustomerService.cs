using System.Collections.Generic;
using System.Threading.Tasks;
using XArbete.Domain.Models;
using XArbete.Services.Data;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        readonly ICustomerDogService _customerDogs;
        public CustomerService(XArbeteContext context,
            ICustomerDogService customerdogs) : base(context)
        {
            _customerDogs = customerdogs;
        }

        public async Task<int> DeleteCustomerDogs(int id)
        {
            var connectedDogs =  _customerDogs.GetMany(a => a.CustomerID == id);
            int dogsCount = 0;
            foreach (var dog in connectedDogs)
            {
                _customerDogs.Delete(dog);
                dogsCount++;
            }
            return dogsCount;
        }

        public IEnumerable<CustomerDog> GetCustomerDogs(int id)
        {
            var a = _customerDogs.GetMany(a => a.CustomerID == id);
            return a;
        }
    }
}
