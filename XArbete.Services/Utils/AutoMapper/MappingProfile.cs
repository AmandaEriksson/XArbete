using AutoMapper;
using XArbete.Web.Customer.Models;
using XArbete.Web.Customer.ViewModels;
using XArbete.Web.DogHotel.Models;
using XArbete.Web.DogHotel.ViewModels;
using XArbete.Web.GuestBook.Models;
using XArbete.Web.GuestBook.ViewModels;
using XArbete.Web.Kennel.Models;
using XArbete.Web.Kennel.ViewModels;
using XArbete.Web.TrainingHall.Models;
using XArbete.Web.TrainingHall.ViewModels;
using XArbete.Web.User.ViewModels;

namespace XArbete.Web.Utils.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HotelBookingViewModel, HotelBooking>();
            CreateMap<HotelBooking, HotelBookingViewModel>();

            CreateMap<TrainingHallBookingViewModel, TrainingHallBooking>();
            CreateMap<TrainingHallBooking, TrainingHallBookingViewModel>();

            CreateMap<CustomerDogViewModel, Dog>();
            CreateMap<Dog, CustomerDogViewModel>();

            CreateMap<CustomerViewModel, XArbete.Web.Customer.Models.Customer>();
            CreateMap<XArbete.Web.Customer.Models.Customer, CustomerViewModel>();

            CreateMap<KennelDogViewModel, KennelDog>();
            CreateMap<KennelDog, KennelDogViewModel>();

            CreateMap<PuppyGroupViewModel, PuppyGroup>();
            CreateMap<PuppyGroup, PuppyGroupViewModel>();

            CreateMap<PuppyViewModel, Puppy>();
            CreateMap<Puppy, PuppyViewModel>();

            CreateMap<RegisterViewModel, XArbete.Web.Customer.Models.Customer>();

            CreateMap<GuestBookCommentViewModel, GuestBookComment>();
            CreateMap<GuestBookComment, GuestBookCommentViewModel>();

            CreateMap<KennelContentViewModel, KennelContent>();
            CreateMap<KennelContent, KennelContentViewModel>(); // kanske inte behövs?? 

            CreateMap<KennelContentSectionViewModel, KennelContentSection>();
            CreateMap<KennelContentSection, KennelContentSectionViewModel>();

        }
    }
}
