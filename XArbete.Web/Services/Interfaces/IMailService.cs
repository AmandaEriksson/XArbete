using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XArbete.Web.Models;

namespace XArbete.Web.Services.Interfaces
{
   public interface IMailService
    {
        Task SendHallMail(Customer customer, TrainingHallBooking booking);
        Task SendHotelMail(Customer customer, HotelBooking booking);

        void CreatePdfContent(HotelBooking booking);
        Task CreateHallCodeMail(Customer customer, TrainingHallBooking booking);

        Task Execute(string email, string subject, StringBuilder message, string filename);
    }
}
