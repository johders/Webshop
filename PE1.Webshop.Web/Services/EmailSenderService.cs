using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using PE1.Webshop.Web.Services.Interfaces;

namespace PE1.Webshop.Web.Services
{
    public class EmailSenderService : IEmailSender
    {
        public void SendEmail(string email, string subject, string body)
        {
            string mail = "pachamamacoffeeburner@outlook.com";
            string password = "Nosugar1!";

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Pachamama Coffee", mail));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate(mail, password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
