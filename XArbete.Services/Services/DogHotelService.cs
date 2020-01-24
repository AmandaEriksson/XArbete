using System.Threading.Tasks;
using XArbete.Domain.Models;
using XArbete.Services.Data;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Services
{
    public class DogHotelService : ServiceBase<HotelBooking>, IDogHotelService
    {
        public DogHotelService(XArbeteContext context) : base(context)
        {
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
        
    }
}
