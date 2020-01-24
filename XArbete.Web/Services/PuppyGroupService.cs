using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Kennel.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Web.Services
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
