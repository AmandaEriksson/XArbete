using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Kennel.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Web.Services
{
    public class KennelDogService : ServiceBase<KennelDog>, IKennelDogService
    {
        private readonly XArbeteContext _context;
        public KennelDogService(XArbeteContext context) : base(context)
        {
            _context = context;
        }

        public void Edit(int id, string name, string about)
        {
            var dog = GetById(id);
            if (name != null)
            {
                dog.Name = name;
            }
            if (about != null)
            {
                dog.About = about;
            }
        }

    }
}
