using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XArbete.Web.Features.Customer.ViewModels;
using XArbete.Web.Features.User.ViewModels;

namespace XArbete.Web.Features.DogHotel.ViewModels
{
    public class HotelBookingViewModel : BaseViewModel
    {
        public HotelBookingViewModel()
        {
            Title = "Boka hundpensionat";
        }

        //fixa här 
        public IEnumerable<CustomerDogViewModel> Dogs { get; set; }

        public int ID { get; set; }

        [Display(Name = "Jag vill lämna")]
        public string From { get; set; }

        [Display(Name = "Jag vill hämta")]
        public string To { get; set; }

        [Display(Name = "Speciella önskemål/bra att veta (allergier etc)")]
        public string CustomerMessage { get; set; }

        public bool CanLiveWithOtherDogs { get; set; }
        public double Price { get; set; }

        [Display(Name = "Pälsvård/bad/kloklipp (300:-)")]
        public bool Grooming { get; set; }

        [Display(Name = "Träning (250:-)")]
        public bool Training { get; set; }

        [Display(Name = "Extra kvällspromenad 1h (250:-)")]
        public bool ExtraWalk { get; set; }

        [Display(Name = "Välj hund")]
        public int DogID { get; set; }

        public CustomerDogViewModel Dog { get; set; }
        public int CustomerID { get; set; }
    }
}
