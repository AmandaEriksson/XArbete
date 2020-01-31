using System.Collections.Generic;
using XArbete.Web.Features.User.ViewModels;

namespace XArbete.Web.Features.GuestBook.ViewModels
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
