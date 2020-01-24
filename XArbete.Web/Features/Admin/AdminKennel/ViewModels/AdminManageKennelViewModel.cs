using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.User.ViewModels;
using XArbete.Web.Kennel.ViewModels;

namespace XArbete.Web.Admin.ViewModels
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

        public IEnumerable<KennelContentViewModel> KennelContents { get; set; }

        public IEnumerable<KennelContentSectionViewModel> KennelContentSections { get; set; }

        public KennelContentSectionViewModel KennelContentSection { get; set; }
    }
}
