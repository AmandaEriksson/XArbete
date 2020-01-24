using System.Threading.Tasks;
using XArbete.Web.DogHotel.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface IDogHotelService : IServiceBase<HotelBooking>
    {
        Task<int> DeleteCustomerBookings(int id);
    }
}
