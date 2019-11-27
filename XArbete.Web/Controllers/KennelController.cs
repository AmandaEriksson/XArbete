using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Controllers
{
    public class KennelController : Controller
    {
        // GET: /<controller>/
        public IActionResult AboutDogs()
        {
            return View();
        }
        public IActionResult BuyPuppy()
        {
            return View();
        }
        public IActionResult EarlierPuppies()
        {
            return View();
        }
        public IActionResult OurDogs()
        {
            return View();
        }
        public IActionResult PlannedPuppies()
        {
            return View();
        }
    }
}
