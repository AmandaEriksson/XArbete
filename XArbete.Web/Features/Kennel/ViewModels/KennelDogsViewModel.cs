using System.Collections.Generic;
using XArbete.Web.User.ViewModels;

namespace XArbete.Web.Kennel.ViewModels
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
