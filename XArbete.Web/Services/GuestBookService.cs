using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.GuestBook.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Web.Services
{
    public class GuestBookService : ServiceBase<GuestBookComment>, IGuestBookService
    {
        public GuestBookService(XArbeteContext context) : base(context)
        {
        }

        public override void Create(GuestBookComment entity)
        {
            entity.CreatedAt = DateTime.Now;
            base.Create(entity);
        }

    }
}
