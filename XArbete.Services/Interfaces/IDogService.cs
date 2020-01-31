using System.Threading.Tasks;
using XArbete.Domain.Models;
namespace XArbete.Web.Services.Interfaces
{
    public interface IDogService : IServiceBase<CustomerDog>
    {
        Task<int> DeleteCustomerDogs(int id);
    }
}
