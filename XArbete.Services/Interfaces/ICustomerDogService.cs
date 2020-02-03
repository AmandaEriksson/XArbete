using System.Threading.Tasks;
using XArbete.Domain.Models;
namespace XArbete.Web.Services.Interfaces
{
    public interface ICustomerDogService : IServiceBase<CustomerDog>
    {
        Task<int> DeleteCustomerDogs(int id);
    }
}
