using XArbete.Services.Data;
using XArbete.Domain.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Services
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
