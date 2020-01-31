using System.Collections.Generic;
using XArbete.Web.Features.User.ViewModels;

namespace XArbete.Web.Features.Admin.AdminContent.ViewModels
{
    public class AdminManageContentViewModel : BaseViewModel
    {
        public AdminManageContentViewModel()
        {
            Title = "Hantera innehåll";
        }
        public IEnumerable<ContentViewModel> KennelContents { get; set; }

        public ContentSectionViewModel KennelContentSection { get; set; }
    }
}
