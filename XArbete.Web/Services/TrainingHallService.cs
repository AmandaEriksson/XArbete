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
    public class TrainingHallService : ServiceBase<TrainingHallBooking>, ITrainingHallService
    {
        private readonly XArbeteContext _context;
        public TrainingHallService(XArbeteContext context) : base(context)
        {
            _context = context;
        }

        public void MarkAsPayed(TrainingHallBooking booking)
        {
            booking.Payed = true;
            _context.SaveChanges();
        }


        //public override TrainingHallBooking GetById(int id)
        //{
        //    return Repository.TrainingHallBookings.SingleOrDefault(a => a.Customer.ID == id);
        //}
    }
}
