using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Controllers
{
    public class GuestBookController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly IGuestBookService _guestBookService;

        public GuestBookController(IToastNotification toastNotification, IGuestBookService guestbookservice)
        {
            _toastNotification = toastNotification;
            _guestBookService = guestbookservice;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var viewmodel = new GuestBookViewModel()
            {
                Comments = _guestBookService.GetAll()
            };
            return View(viewmodel);
        }
        public IActionResult NewComment(GuestBookViewModel model)
        {
            _guestBookService.Create(model.Comment);
            _toastNotification.AddSuccessToastMessage($"Tack för din kommentar!");

            return RedirectToAction("Index");
        }
    }
}
