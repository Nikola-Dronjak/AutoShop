using Microsoft.AspNetCore.Identity.UI.Services;

namespace AutoShop.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Logic for sending an email
            return Task.CompletedTask;
        }
    }
}
