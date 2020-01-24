using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Kennel.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface IPuppyService : IServiceBase<Puppy>
    {
        void ChangeStatus(int id, bool status);
        void Edit(int id, string name);
    }
}
