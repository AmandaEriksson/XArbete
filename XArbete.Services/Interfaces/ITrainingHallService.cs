using System.Threading.Tasks;
using XArbete.Domain.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface ITrainingHallService : IServiceBase<TrainingHallBooking>
    {
        void MarkAsPayed(TrainingHallBooking booking);
        Task<int> DeleteCustomerBookings(int id);
    }
}
