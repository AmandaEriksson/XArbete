using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XArbete.Web.DogHotel.ViewModels;
using XArbete.Web.TrainingHall.ViewModels;
using XArbete.Web.User.ViewModels;

namespace XArbete.Web.Customer.ViewModels
{
    public class CustomersAdminViewModel : BaseViewModel
    {
        public CustomersAdminViewModel()
        {
            Title = "Mina sidor";
            Description = "Här kan du granska och ändra dina uppgifter, lägga till/ta bort hundar samt hantera dina bokningar.";
        }
        public CustomerViewModel Customer { get; set; }

        public CustomerDogViewModel Dog { get; set; }

        public IEnumerable<CustomerDogViewModel> Dogs { get; set; }

        public IEnumerable<HotelBookingViewModel> HotelBookings { get; set; }

        public IEnumerable<TrainingHallBookingViewModel> TrainingHallBookings { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Verifiera lösenord")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
