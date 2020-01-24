using XArbete.Services.Data;
using XArbete.Domain.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Services
{
    public class KennelContentService : ServiceBase<KennelContent>, IKennelContentService
    {
        public KennelContentService(XArbeteContext context) : base(context)
        {
        }
    }
}
