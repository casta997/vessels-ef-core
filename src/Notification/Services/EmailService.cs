using Notification.Interfaces;

namespace Notification.Services
{
    public class EmailService : IEmailService
    {
        public string send(string msg)
        {
            string mail = msg + " I'm a mail";
            return mail;
        }
    }
}
