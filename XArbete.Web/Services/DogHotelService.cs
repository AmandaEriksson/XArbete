using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Web.Services
{
    public class DogHotelService : ServiceBase<HotelBooking>,IDogHotelService
    {
        public DogHotelService(XArbeteContext context) : base(context)
        {
        }
 

        //public override HotelBooking GetById(int id)
        //{
        //    return Repository.HotelBookings.SingleOrDefault(a => a.Customer.ID == id);
        //}
    }
}
