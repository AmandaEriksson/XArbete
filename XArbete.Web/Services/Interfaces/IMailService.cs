using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XArbete.Web.DogHotel.Models;
using XArbete.Web.TrainingHall.Models;


namespace XArbete.Web.Services.Interfaces
{
   public interface IMailService
    {
        Task SendHallMail(XArbete.Web.Customer.Models.Customer customer, TrainingHallBooking booking);
        Task SendHotelMail(XArbete.Web.Customer.Models.Customer customer, HotelBooking booking);

        Task CreatePdfContent(HotelBooking booking);
        Task CreateHallCodeMail(XArbete.Web.Customer.Models.Customer customer, TrainingHallBooking booking);

        Task Execute(string email, string subject, StringBuilder message, string filename);

        Task NewPassword(string email, string newPass);
    }
}
