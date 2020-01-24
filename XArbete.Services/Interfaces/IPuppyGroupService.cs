using XArbete.Domain.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface IPuppyGroupService : IServiceBase<PuppyGroup>
    {
        void ChangeStatus(PuppyGroup group, int value);
    }
}
