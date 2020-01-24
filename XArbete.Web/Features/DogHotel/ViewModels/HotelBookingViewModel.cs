using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XArbete.Web.Customer.ViewModels;
using XArbete.Web.User.ViewModels;

namespace XArbete.Web.DogHotel.ViewModels
{
    public class HotelBookingViewModel : BaseViewModel
    {
        public HotelBookingViewModel()
        {
            Title = "Boka hundpensionat";
        }
        public IEnumerable<CustomerDogViewModel> Dogs { get; set; }

        public int ID { get; set; }

        [Display(Name = "Jag vill lämna")]
        public string From { get; set; }

        [Display(Name = "Jag vill hämta")]
        public string To { get; set; }

        [Display(Name = "Speciella önskemål/bra att veta")]
        public string CustomerMessage { get; set; }

        public double Price { get; set; }

        [Display(Name = "Pälsvård/bad/kloklipp (300:-)")]
        public bool Grooming { get; set; }

        [Display(Name = "Träning (250:-)")]
        public bool Training { get; set; }

        [Display(Name = "Extra kvällspromenad 1h (250:-)")]
        public bool ExtraWalk { get; set; }

        [Display(Name = "Välj hund")]
        public int DogID { get; set; }

        public int CustomerID { get; set; }
    }
}
