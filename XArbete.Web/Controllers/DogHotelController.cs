﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult NewBooking(string dog, DateTime fromdate)
        {
            return View();
        }
    }
}
