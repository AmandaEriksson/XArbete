using System.Text;
using System.Threading.Tasks;
using XArbete.Domain.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface IMailService
    {
        Task SendHallMail(Customer customer, TrainingHallBooking booking);
        Task SendHotelMail(Customer customer, HotelBooking booking);

        Task CreatePdfContent(HotelBooking booking);
        Task CreateHallCodeMail(Customer customer, TrainingHallBooking booking);

        Task Execute(string email, string subject, StringBuilder message, string filename);

        Task NewPassword(string email, string newPass);
    }
}
