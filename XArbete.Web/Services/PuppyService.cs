using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Kennel.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Web.Services
{
    public class PuppyService : ServiceBase<Puppy>, IPuppyService
    {
        private readonly XArbeteContext _context;
        public PuppyService(XArbeteContext context) : base(context)
        {
            _context = context;
        }

        public void ChangeStatus(int id, bool status)
        {
            var pup = GetSingle(a => a.ID == id);

            pup.Sold = status;
        }

        public void Edit(int id, string name)
        {
            var pup = GetById(id);
            pup.Name = name;
        }
    }
}
