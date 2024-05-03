using PE1.Webshop.Web.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace PE1.Webshop.Web.Services
{
    public class EmailSenderService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string body)
        {
            string mail = "pachamamacoffeeburner@outlook.com";
            string password = "Nosugar1!";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, password)
            };

            return client.SendMailAsync(
                new MailMessage(
                    from: mail, 
                    to: email, 
                    subject: subject, 
                    body: body));
        }
    }
}
