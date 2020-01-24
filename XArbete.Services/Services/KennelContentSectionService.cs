using XArbete.Services.Data;
using XArbete.Domain.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Services
{
    public class KennelContentSectionService : ServiceBase<KennelContentSection>, IKennelContentSectionService
    {
        public KennelContentSectionService(XArbeteContext context) : base(context)
        {
        }
    }
}
