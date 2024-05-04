namespace PE1.Webshop.Web.Services.Interfaces
{
    public interface IEmailSender
    {
        public void SendEmail(string email, string subject, string body);
    }
}
