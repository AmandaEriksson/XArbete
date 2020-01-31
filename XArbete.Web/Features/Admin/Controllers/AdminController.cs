using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Collections.Generic;
using System.Threading.Tasks;
using XArbete.Web.Features.Admin.ViewModels;
using XArbete.Web.Services.Interfaces;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.Admin.Controllers
{
    public class AdminController : Controller
    {
        IToastNotification _toastNotification;
        IUserService _userService;
        IContentService _contentService;
        IMapper _mapper;

        public AdminController(IToastNotification toastNotification,
            IUserService userService, IContentService contentservice, IMapper mapper
            )
        {
            _toastNotification = toastNotification;
            _userService = userService;
            _contentService = contentservice;
            _mapper = mapper;

        }

        public IActionResult Edit()
        {
            var model = new AdminEditViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AdminEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userService.GetSingleAsync(a => a.Email == User.Identity.Name);

            var result = await _userService.UpdatePassword(user.Id, model.Password);
            if (result)
            {
                _toastNotification.AddSuccessToastMessage("Ditt lösenord är ändrat och dina uppgifter sparade.");
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Något gick fel.");

            }
            return RedirectToAction("Edit");
        }
       

    }
}
