using System.Net.Mail;

namespace Agathas.Storefront.Core.Email
{
    public class SMTPEmailService : IEmailService
    {
        public void SendMail(string from, string to, string subject, string body)
        {
            var message = new MailMessage
            {
                Subject = subject,
                Body = body
            };
            var smtp = new SmtpClient();
            smtp.Send(message);
        }
    }
}
