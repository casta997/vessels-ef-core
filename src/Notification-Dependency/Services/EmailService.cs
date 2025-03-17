using Notification_Dependency.Interfaces;

namespace Notification_Dependency.Services
{
    public class EmailService : IEmailService
    {
        public void send(string msg)
        {
            Console.WriteLine(msg + " I'm a mail");
        }
    }
}
