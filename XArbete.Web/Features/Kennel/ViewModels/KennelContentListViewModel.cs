using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.User.ViewModels;

namespace XArbete.Web.Kennel.ViewModels
{
    public class KennelContentListViewModel : BaseViewModel
    {
        public List <KennelContentViewModel> KennelContents { get; set; }
    }
}
