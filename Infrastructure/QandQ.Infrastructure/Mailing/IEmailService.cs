namespace QandQ.Infrastructure.Mailing
{
    public interface IEmailService
    {
        void SendEmail(string Email, string MailSubject, string MailMessage);
    }
}
