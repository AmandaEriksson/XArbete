using XArbete.Services.Data;
using XArbete.Domain.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Services
{
    public class ContentSectionService : ServiceBase<ContentSection>, IContentSectionService
    {
        public ContentSectionService(XArbeteContext context) : base(context)
        {
        }
    }
}
