namespace PE1.Webshop.Web.Services.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}
