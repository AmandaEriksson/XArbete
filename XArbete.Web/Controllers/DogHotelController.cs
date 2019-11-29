using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XArbete.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Controllers
{
    public class DogHotelController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Book()
        {
            return View("Book");
        }
        public IActionResult PriceInfo()
        {
            return View();
        }

        public IActionResult NewBooking(HotelBooking booking)
        {
            var fromdate = Convert.ToDateTime(booking.From);
            var todate = Convert.ToDateTime(booking.To);

            var book = new HotelBooking()
            {
                ID = Repository.HotelBookings.Max(a => a.ID) + 1,
                CustomerID = 2,
                DogID = booking.DogID,
                From = booking.From,
                To = booking.To,
                CanLiveWithOtherDogs = false,
                CustomerMessage = "Min hund tycker om att leka och söka"
            };
            return View();
        }
    }
}
