using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.Data;
using XArbete.Web.DogHotel.Models;

namespace XArbete.Web.Services
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
