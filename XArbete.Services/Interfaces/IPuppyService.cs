using XArbete.Domain.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface IPuppyService : IServiceBase<Puppy>
    {
        void ChangeStatus(int id, bool status);
        void Edit(int id, string name);
    }
}
