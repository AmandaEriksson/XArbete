
namespace XArbete.Web.User.ViewModels
{
    public class BaseViewModel
    {
        public RegisterViewModel RegisterViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }

        public string Title { get; set; }

        public virtual string Description { get; set; }
    }
}
