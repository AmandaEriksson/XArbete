using System.Collections.Generic;
using XArbete.Web.Features.User.ViewModels;

namespace XArbete.Web.Features.Kennel.ViewModels
{
    public class PuppyGroupsViewModel : BaseViewModel
    {
        public List<PuppyGroupViewModel> ActivePuppyGroups { get; set; }
        public List<PuppyGroupViewModel> PassedPuppyGroups { get; set; }
        public List<PuppyGroupViewModel> PlannedPuppyGroups { get; set; }
    }
}
