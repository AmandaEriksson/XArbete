using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface ITrainingHallService : IServiceBase<TrainingHallBooking>
    {
        void MarkAsPayed(TrainingHallBooking booking);
    }
}
