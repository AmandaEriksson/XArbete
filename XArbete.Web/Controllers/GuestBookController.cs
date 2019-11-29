using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XArbete.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Controllers
{
    public class GuestBookController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var viewmodel = new GuestBookViewModel()
            {
                Comments = Repository.GuestBookComments
                // hämta kommentarer från databasen
            };
            return View(viewmodel);
        }
        public IActionResult NewComment(GuestBookViewModel model)
        {
            model.Comment.CreatedAt = DateTime.Now;
            Repository.GuestBookComments.Add(model.Comment);
            // save comment
            return RedirectToAction("Index");
        }
    }
}
