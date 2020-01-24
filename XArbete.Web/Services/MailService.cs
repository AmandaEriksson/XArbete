using EASendMail;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using XArbete.Web.TrainingHall.Models;
using XArbete.Web.DogHotel.Models;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.Utils.Constants;
using XArbete.Web.Utils.Services;
using Microsoft.AspNetCore.Mvc;

namespace XArbete.Web.Services
{
    public class MailService : IMailService
    {
        private readonly WebOptions _webOptions;
        private readonly IDogService _dogService;

        public MailService(IOptions<WebOptions> weboptions, IDogService dogservice)
        {
            _webOptions = weboptions.Value;
            _dogService = dogservice;
        }
        public async Task CreateHallCodeMail(XArbete.Web.Customer.Models.Customer customer, TrainingHallBooking booking)
        {
            var subject = $"Tack för din betalning!";
            var body = new StringBuilder();
            body.AppendLine($"<h1>Hej {customer.Name}, din betalning för träningshallen {booking.StartTime} är registrerad!</h1>");
            body.AppendLine($"<p>Din dörrkod som gäller är <strong> 123 </strong></p>");
            body.AppendLine($"<p>Välkommen! </strong></p>");
            body.AppendLine($"<small>{customer.Email} </small>");


            await Execute(customer.Email, subject, body);
        }

        public async Task SendHallMail(XArbete.Web.Customer.Models.Customer customer, TrainingHallBooking booking)
        {
            var subject = $"Bokningsbekräftelse";
            var body = new StringBuilder();
            body.AppendLine($"<h1>Hej {customer.Name}, tack för din bokning av våran träningshall!</h1>");
            body.AppendLine($"<p>Du har bokat träningshallen den {booking.StartTime.ToString("yyyy-MM-dd")} från kl {booking.StartTime.ToString("HH:mm")} till kl {booking.EndTime.ToString("HH:mm")}.</p>");
            body.AppendLine($"<p> Totala kostnaden för din bokning är: {booking.Price} kr. Se våran <a href='https://localhost:44347/TrainingHall/PriceInfo'> prisinfo</a> för mer detaljer.</p>");
            body.AppendLine($"<p>För att garantera att hinna få koden till dörren måste betalningen inkomma till oss minst 12 timmar innan starttiden.</p>");
            body.AppendLine($"<p>När betalningen är genomförd får du ett nytt mail med dörrkod.</p>");
            body.AppendLine($"<small>({customer.Email})</small>");

            await Execute(customer.Email, subject, body);

        }

        public async Task SendHotelMail(XArbete.Web.Customer.Models.Customer customer, HotelBooking booking)
        {
            var subject = $"Bokningsbekräftelse";
            var body = new StringBuilder();
            body.AppendLine($"<h1>Hej {customer.Name}, tack för din bokning på vårat hundpensionat!</h1>");
            body.AppendLine($"<p>Du har bokat avlämning den {booking.From.ToString("yyyy-MM-dd")} kl  {booking.From.ToString("HH:mm")}, samt avhämtning igen den {booking.To.ToString("yyyy-MM-dd")} kl {booking.To.ToString("HH:mm")}.</p>");
            body.AppendLine($"<p>Kostnad: {booking.Price} kr, betalas vid avlämning. </p>");
            body.AppendLine($"<p></p>");
            body.AppendLine($"<p>Se bifogad bokningsbekräftelse för detaljer om din bokning.</p>");
            body.AppendLine($"<p></p>");
            body.AppendLine($"<h1><strong> Välkommen! </strong></h1>");
            body.AppendLine($"<small>({customer.Email})</small>");

            await Execute(customer.Email, subject, body, $"{booking.ID}.pdf");
        }

        public async Task CreatePdfContent(HotelBooking booking)
        {
            var body = new StringBuilder();
            body.AppendLine($"<h1>Bokningsbekräftelse</h1>");
            body.AppendLine($"<p>Du har bokat följande:</p>");
            body.AppendLine($"<p></p>");

            body.AppendLine($"<h3>Hundpensionat för <strong> {_dogService.GetById(booking.DogID).Name} </strong> </h3>");
            body.AppendLine($"<p></p>");
            body.AppendLine($"<p>Från: {booking.From.ToString("yyyy-MM-dd HH:mm")}");
            body.AppendLine($"<p>Till: {booking.To.ToString("yyyy-MM-dd HH:mm")}");
            body.AppendLine($"<p>Totalt antal dagar: {(booking.To - booking.From).Days} ({PriceContants.HotelPriceOneNight}/dag) = {(booking.To - booking.From).Days * PriceContants.HotelPriceOneNight} kr</p>");

            body.AppendLine($"<p></p>");
            body.AppendLine($"<h4><strong>Tillägg:</strong></h4>");
            body.AppendLine($"<ul>");

            if (booking.Grooming)
                body.AppendLine($"<li>Bad/borstning/kloklipp = {PriceContants.Grooming} kr</li>");
            if (booking.Training)
                body.AppendLine($"<li>Träning 1h = {PriceContants.Training} kr</li>");
            if (booking.ExtraWalk)
                body.AppendLine($"<li>Extra kvällspromenad = {PriceContants.ExtraWalk} kr</li>");
            if (!booking.Grooming && !booking.Training && !booking.ExtraWalk)
                body.AppendLine($"<li>Inga tillägg</li>");

            body.AppendLine($"</ul>");
            body.AppendLine($"<p></p>");

            if (booking.CustomerMessage != null)
            {
                body.AppendLine($"<p>Speciella önskemål: {booking.CustomerMessage}</p>");
            }
            else
            {
                body.AppendLine($"<p>Inga speciella önskemål</p>");

            }

            body.AppendLine($"<h2>Total summa: {booking.Price} kr (betalas vid avlämning)</h2>");

          
                var pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                var htmlparser = new HTMLWorker(pdfDoc);
                using (var memoryStream = new MemoryStream())
                {
                    var writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    pdfDoc.Open();

                    htmlparser.Parse(new StringReader(body.ToString()));
                    pdfDoc.Close();

                    byte[] bytes = memoryStream.ToArray();
                    File.WriteAllBytes($@"Content/Invoices/{booking.ID}.pdf", bytes);

                    memoryStream.Close();
                }
            
        }

        public async Task Execute(string email, string subject, StringBuilder message, string filename = null)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // HARDCODED
                oMail.From = "stollan97@hotmail.com";
                oMail.To = "stollan97@hotmail.com";

                oMail.Subject = subject;
                oMail.HtmlBody = message.ToString();

                if (filename != null)
                {
                    oMail.AddAttachment($@"Content/Invoices/{filename}");

                }
                SmtpServer oServer = new SmtpServer(_webOptions.EmailServiceValues.Host, _webOptions.EmailServiceValues.Port);

                oServer.User = _webOptions.EmailServiceValues.SenderAddress;
                oServer.Password = _webOptions.EmailServiceValues.Password;

                oServer.ConnectType = SmtpConnectType.ConnectSTARTTLS;
                SmtpClient oSmtp = new SmtpClient();

                // sendmailasync method missing?

                SmtpClientAsyncResult oResult = oSmtp.BeginSendMail(
                        oServer, oMail, null, null);
                while (!oResult.IsCompleted)
                {
                    oResult.AsyncWaitHandle.WaitOne(50, false);
                }
                 oSmtp.EndSendMail(oResult);
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }

        public async Task NewPassword(string email, string newPass)
        {
            var subject = $"Glömt lösenord";
            var body = new StringBuilder();
            body.AppendLine($"<h1>{email}</h1>");
            body.AppendLine($"<h3>Du har ansökt om ett nytt lösenord.</h3>");
            body.AppendLine($"<p>Ditt nya tillfälliga lösenord är {newPass}.</p>");
            body.AppendLine($"<p>Kopiera det och klistra in vid inloggning och ändra ditt lösenord direkt till något du kommer ihåg.</p>");

            await Execute(email, subject, body);
        }
    }
}

