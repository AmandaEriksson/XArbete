using System.Threading.Tasks;
using XArbete.Domain.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface IDogHotelService : IServiceBase<HotelBooking>
    {
        Task<int> DeleteCustomerBookings(int id);
    }
}
