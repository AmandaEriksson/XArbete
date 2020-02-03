using AutoMapper;
using XArbete.Domain.Models;
using XArbete.Web.Features.Admin.AdminContent.ViewModels;
using XArbete.Web.Features.Course.ViewModels;
using XArbete.Web.Features.Customer.ViewModels;
using XArbete.Web.Features.DogHotel.ViewModels;
using XArbete.Web.Features.GuestBook.ViewModels;
using XArbete.Web.Features.Kennel.ViewModels;
using XArbete.Web.Features.TrainingHall.ViewModels;
using XArbete.Web.Features.User.ViewModels;

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

            CreateMap<CustomerDogViewModel, CustomerDog>();
            CreateMap<CustomerDog, CustomerDogViewModel>();

            CreateMap<CustomerViewModel, XArbete.Domain.Models.Customer>();
            CreateMap<XArbete.Domain.Models.Customer, CustomerViewModel>();

            CreateMap<KennelDogViewModel, KennelDog>();
            CreateMap<KennelDog, KennelDogViewModel>();

            CreateMap<PuppyGroupViewModel, PuppyGroup>();
            CreateMap<PuppyGroup, PuppyGroupViewModel>();

            CreateMap<PuppyViewModel, Puppy>();
            CreateMap<Puppy, PuppyViewModel>();

            CreateMap<RegisterViewModel, XArbete.Domain.Models.Customer>();

            CreateMap<GuestBookCommentViewModel, GuestBookComment>();
            CreateMap<GuestBookComment, GuestBookCommentViewModel>();

            CreateMap<ContentViewModel, Content>();
            CreateMap<Content, ContentViewModel>();

            CreateMap<ContentSectionViewModel, ContentSection>();
            CreateMap<ContentSection, ContentSectionViewModel>();

            CreateMap<Course, CourseViewModel>();
            CreateMap<CourseViewModel, Course>();

        }
    }
}
