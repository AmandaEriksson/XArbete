using System.Security.Claims;
using System.Threading.Tasks;
using XArbete.Domain.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface IUserService : IServiceBase<ApplicationUser>
    {
        Task SignIn(ApplicationUser model);
        Task<bool> SignOut();
        Task<ApplicationUser> ValidateUser(string username, string password);
        Task<ApplicationUser> CreateUser(string email, string password, string name, string role);
        Task<bool> UpdatePassword(string appUserId, string password);
        //Task<bool> CurrentUserIsAdmin(ApplicationUser user); // TODO kan tas bort 
        Task<bool> IsSignedIn(ClaimsPrincipal user);
        string Role(bool isAdmin);
        void DeleteByUserId(string id);

        string GeneratePassword();

    }
}
