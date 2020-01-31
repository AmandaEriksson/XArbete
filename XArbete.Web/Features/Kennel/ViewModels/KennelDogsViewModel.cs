using System.Collections.Generic;
using XArbete.Web.Features.User.ViewModels;

namespace XArbete.Web.Features.Kennel.ViewModels
{
    public class KennelDogsViewModel : BaseViewModel
    {
        public KennelDogsViewModel()
        {
            Title = "Våra hundar";
        }
        public IEnumerable<KennelDogViewModel> Dogs { get; set; }
    }
}
