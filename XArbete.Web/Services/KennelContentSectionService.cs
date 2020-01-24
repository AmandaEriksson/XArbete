using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Kennel.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Web.Services
{
    public class KennelContentSectionService : ServiceBase<KennelContentSection>, IKennelContentSectionService
    {
        public KennelContentSectionService(XArbeteContext context) : base(context)
        {
        }
    }
}
