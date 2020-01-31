using System.Collections.Generic;
using System.Threading.Tasks;
using XArbete.Domain.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface ICustomerService : IServiceBase<Customer>
    {
        IEnumerable<CustomerDog> GetCustomerDogs(int id);
        Task<int> DeleteCustomerDogs(int id);
    }
}
