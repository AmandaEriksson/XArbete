using System;
using XArbete.Services.Data;
using XArbete.Domain.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Services
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
