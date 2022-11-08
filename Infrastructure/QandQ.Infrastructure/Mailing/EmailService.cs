using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace QandQ.Infrastructure.Mailing
{
    public class EmailService : IEmailService
    {
        EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public void SendEmail(string Email, string MailSubject, string MailMessage)
        {
            MailMessage message = new MailMessage();

            message.Subject = MailSubject;
            message.From = new MailAddress(_emailSettings.From, _emailSettings.UserName);
            message.To.Add(new MailAddress(Email));
            message.Body = MailMessage;
            message.Priority = MailPriority.High;

            // Host ve Port Gereklidir!
            SmtpClient smtp = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port);
            NetworkCredential AccountInfo = new NetworkCredential(_emailSettings.From, _emailSettings.Password);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
    }
}
