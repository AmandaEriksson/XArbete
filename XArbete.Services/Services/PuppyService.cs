using XArbete.Services.Data;
using XArbete.Domain.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Services
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
            var pup = GetSingle(a => a.PuppyId == id);

            pup.Sold = status;
        }

        public void Edit(int id, string name)
        {
            var pup = GetById(id);
            pup.Name = name;
        }
    }
}
