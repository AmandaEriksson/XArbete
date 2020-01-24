using System.Collections.Generic;
using XArbete.Web.User.ViewModels;

namespace XArbete.Web.GuestBook.ViewModels
{
    public class GuestBookViewModel : BaseViewModel
    {
        public GuestBookViewModel()
        {
            Title = "Gästbok";
            Description = "Här kan du läsa och skriva en kommentar i våran gästbok";
        }
        public IEnumerable<GuestBookCommentViewModel> Comments { get; set; }

        public GuestBookCommentViewModel Comment { get; set; }
    }
}
