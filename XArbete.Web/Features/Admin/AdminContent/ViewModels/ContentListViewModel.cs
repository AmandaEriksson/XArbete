using System.Collections.Generic;
using XArbete.Web.Features.User.ViewModels;

namespace XArbete.Web.Features.Admin.AdminContent.ViewModels
{
    public class ContentListViewModel : BaseViewModel
    {
        public List <ContentViewModel> KennelContents { get; set; }

        public ContentViewModel KennelContent { get; set; }
    }
}
