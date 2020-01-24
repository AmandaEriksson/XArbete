using XArbete.Services.Data;
using XArbete.Domain.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Services
{
    public class PuppyGroupService : ServiceBase<PuppyGroup>, IPuppyGroupService
    {
        public PuppyGroupService(XArbeteContext context) : base(context)
        {
        }

        public void ChangeStatus(PuppyGroup group, int value)
        {
            group.Status = value;
        }
    }
}
