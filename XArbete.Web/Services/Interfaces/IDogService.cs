using System.Threading.Tasks;
using XArbete.Web.Customer.Models;
namespace XArbete.Web.Services.Interfaces
{
    public interface IDogService : IServiceBase<Dog>
    {
        Task<int> DeleteCustomerDogs(int id);
    }
}
