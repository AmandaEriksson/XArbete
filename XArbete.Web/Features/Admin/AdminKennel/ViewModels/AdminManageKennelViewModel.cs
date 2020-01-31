using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Features.User.ViewModels;
using XArbete.Web.Features.Kennel.ViewModels;
using XArbete.Web.Features.Admin.ViewModels;
using XArbete.Web.Features.Admin.AdminContent.ViewModels;

namespace XArbete.Web.Features.Admin.AdminKennel.ViewModels
{
    public class AdminManageKennelViewModel : BaseViewModel
    {
        public AdminManageKennelViewModel()
        {
            Title = "Hantera kenneln";
        }
        public KennelDogViewModel Dog { get; set; }

        public PuppyGroupViewModel PuppyGroup { get; set; }

        public PuppyViewModel Puppy { get; set; }

        public IEnumerable<PuppyViewModel> Puppies {get;set;}
        public IEnumerable<KennelDogViewModel> Dogs { get; set; }

        public IEnumerable<PuppyGroupViewModel> PuppyGroups { get; set; }

        public ContentViewModel ContentModel { get; set; }
        //public IEnumerable<KennelContentViewModel> KennelContents { get; set; }

        //public IEnumerable<KennelContentSectionViewModel> KennelContentSections { get; set; }

        //public KennelContentSectionViewModel KennelContentSection { get; set; }
    }
}
