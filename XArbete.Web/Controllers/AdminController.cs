using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult ManageCustomers()
        {
            return View();
        }
        public IActionResult ManageBookings()
        {
            return View();
        }
    }
}
