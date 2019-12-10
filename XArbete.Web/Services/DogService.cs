using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Web.Services
{
    public class DogService : ServiceBase<Dog>, IDogService
    {
        public DogService(XArbeteContext context) : base(context)
        {
        }

        //public override Dog GetById(int id)
        //{
        //    return Repository.Dogs.SingleOrDefault(a => a.ID == id);
        //}

    }
}
