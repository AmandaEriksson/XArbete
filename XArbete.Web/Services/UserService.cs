using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.User.Models;
using XArbete.Web.Utils.Constants;

namespace XArbete.Web.Services
{
    public class UserService : ServiceBase<ApplicationUser>, IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserService(UserManager<ApplicationUser> usermanager,
            SignInManager<ApplicationUser> signinmanager, XArbeteContext context) : base(context)
        {
            _userManager = usermanager;
            _signInManager = signinmanager;
        }

        public async Task<ApplicationUser> CreateUser(string email, string password, string name, string role)
        {
            //skapar appuser
            var user = new ApplicationUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            //addar till roll
            await _userManager.AddToRoleAsync(user, role);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().ToString());
            }
            return user;
        }

        public string Role(bool isAdmin)
        {
            if (isAdmin)
                return RoleConstants.Adminstrator;
            else
                return RoleConstants.Customer;
        }

        public async Task SignIn(ApplicationUser user)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<bool> SignOut()
        {
            return _signInManager.SignOutAsync().IsCompletedSuccessfully;
        }

        public async Task<bool> UpdatePassword(string userId, string password)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var removeOldPass = await _userManager.RemovePasswordAsync(user);
            if (!removeOldPass.Succeeded)
            {
                return false;
            }
            var addNewPass = await _userManager.AddPasswordAsync(user, password);
            if (!addNewPass.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<ApplicationUser> ValidateUser(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            var validCredentials = await _signInManager.UserManager.CheckPasswordAsync(user, password);
            if (!validCredentials)
            {
                throw new Exception("Fel inloggningsuppgifter, försök igen");

            }
            return user;
        }


        public async Task<bool> IsSignedIn(ClaimsPrincipal user)
        {
            return _signInManager.IsSignedIn(user);
        }

        public void DeleteByUserId(string id)
        {
            var entity = DbSet.Find(id);
            Delete(entity);
        }

        public string GeneratePassword()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            int count = 0;
            while (count < 10)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
                count++;
            }

            return res.ToString();
        }
    }
}
