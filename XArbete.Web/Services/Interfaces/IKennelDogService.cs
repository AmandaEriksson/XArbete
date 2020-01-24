using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Kennel.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface IKennelDogService : IServiceBase<KennelDog>
    {
        void Edit(int id, string name, string about);
    }
}
