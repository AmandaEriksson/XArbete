using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XArbete.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = Repository.Customers.SingleOrDefault(a => a.CustomerID == 1);
            return View(model);
        }
        public IActionResult Login(string email, string password)
        {
            return View();
        }

        public IActionResult Register(string email, string password)
        {
            return View();
        }

        public IActionResult AddDog(string name, string sex, string img)
        {
            var dog = new Dog()
            {
                ID = 3,
                Name = name,
                CustomerID = 1,
                Sex = sex,
                Img = img
            };
            Repository.Dogs.Add(dog);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateInfo(Customer cust)
        {
            var customer = Repository.Customers.SingleOrDefault(a => a.CustomerID == cust.CustomerID);
            customer.Name = cust.Name;
            customer.Number = cust.Number;

            return RedirectToAction("Index");
        }

        public IActionResult RemoveDog(int id)
        {
            var dogToRemove = Repository.Dogs.SingleOrDefault(a => a.ID == id);
            Repository.Dogs.Remove(dogToRemove);
            return RedirectToAction("Index");
        }
    }
}
