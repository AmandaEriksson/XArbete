﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Domain.Models;
using XArbete.Web.Features.GuestBook.ViewModels;
using XArbete.Web.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.GuestBook.Controllers
{
    public class GuestBookController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly IGuestBookService _guestBookService;
        private readonly IMapper _mapper;

        public GuestBookController(IToastNotification toastNotification, IGuestBookService guestbookservice, IMapper mapper)
        {
            _toastNotification = toastNotification;
            _guestBookService = guestbookservice;
            _mapper = mapper;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var viewmodel = new GuestBookViewModel()
            {
                Comments = _mapper.Map<List<GuestBookCommentViewModel>>(_guestBookService.GetAll())
            };
            return View(viewmodel);
        }
        public async Task<IActionResult> NewComment(GuestBookViewModel model)
        {
            _guestBookService.Create(_mapper.Map<GuestBookComment>(model.Comment));
            await _guestBookService.CommitAsync();
            _toastNotification.AddSuccessToastMessage($"Tack för din kommentar!");

            return RedirectToAction("Index");
        }
    }
}
