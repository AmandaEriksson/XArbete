using XArbete.Domain.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface IKennelDogService : IServiceBase<KennelDog>
    {
        void Edit(int id, string name, string about);
    }
}
