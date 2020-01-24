using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Kennel.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Web.Services
{
    public class KennelContentService : ServiceBase<KennelContent>, IKennelContentService
    {
        public KennelContentService(XArbeteContext context) : base(context)
        {
        }
    }
}
