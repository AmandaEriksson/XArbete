using System.Threading.Tasks;
using XArbete.Services.Data;
using XArbete.Domain.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Services
{
    public class TrainingHallService : ServiceBase<TrainingHallBooking>, ITrainingHallService
    {
        private readonly XArbeteContext _context;
        public TrainingHallService(XArbeteContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> DeleteCustomerBookings(int id)
        {
                int bookingsCount = 0;
                foreach (var booking in GetMany(a => a.CustomerID == id))
                {
                    Delete(booking);
                    bookingsCount++;
                }

                return bookingsCount;
            
        }

        public void MarkAsPayed(TrainingHallBooking booking)
        {
            booking.Payed = true;
        }

    }
}
