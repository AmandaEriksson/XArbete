using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Threading.Tasks;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.Features.User.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.User.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private readonly IToastNotification _toastNotification;
        private readonly IMailService _mailService;
        readonly IMapper _mapper;
        public UserController(IUserService userservice,
            ICustomerService customerservice,
            IToastNotification toastnotificaiton,
            IMailService mailservice,
            IMapper mapper)
        {
            _userService = userservice;
            _customerService = customerservice;
            _toastNotification = toastnotificaiton;
            _mailService = mailservice;
            _mapper = mapper;
        }
        // GET: /<controller>/
        public async Task<IActionResult> LogOut()
        {
            await _userService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(BaseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userService.ValidateUser(model.LoginViewModel.Email, model.LoginViewModel.Password);
                    var customer = await _customerService.GetSingleAsync(a => a.ApplicationUserID == user.Id);
                    await _userService.SignIn(user);

                    if (customer.IsAdmin)
                    {
                        return RedirectToAction("ManageCustomers", "AdminCustomers");
                    }
                    return RedirectToAction("Index", "Customer");
                }
                catch (Exception e)
                {
                    _toastNotification.AddErrorToastMessage($"Följande gick fel: {e.Message}");
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View( model);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userService.CreateUser(model.Email,
                        model.Password, model.Name,
                        _userService.Role(model.IsAdmin));

                    var customer = _mapper.Map<XArbete.Domain.Models.Customer>(model);
                    customer.ApplicationUserID = user.Id;

                    _customerService.Create(customer);
                    await _customerService.CommitAsync();
                    await _userService.SignIn(user);

                    if (customer.IsAdmin)
                    {
                        return RedirectToAction("ReloadCustomers", "AdminCustomers");
                    }
                    _toastNotification.AddSuccessToastMessage("Du är registrerad och inloggad.");
                    return RedirectToAction("Index", "Customer");
                }
                catch (Exception e)
                {
                    _toastNotification.AddErrorToastMessage(e.Message);
                    return Json(new { success = false });
                    throw;
                }
            }

            _toastNotification.AddErrorToastMessage("Något gick fel, kontakta support");
            return Json(new { success = false });
        }

        public async Task<IActionResult> ForgotPassword(BaseViewModel model)
        {
            var user = _userService.GetSingle(a => a.Email == model.LoginViewModel.Email);
            var newPass = _userService.GeneratePassword();
            await _userService.UpdatePassword(user.Id, newPass);
            await _userService.CommitAsync();
            await _mailService.NewPassword(user.Email, newPass);

            _toastNotification.AddInfoToastMessage("Kolla i din mejl för ditt nya tillfälliga lösenord.");
            return RedirectToAction("Index", "Home");
        }
    }
}
