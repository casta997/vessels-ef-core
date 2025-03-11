using Dependency03.Interfaces;

namespace Dependency03.Services
{
    public class EmailService :INotificationService
    {
        public void Send(string msg)
        {
            Console.WriteLine(msg + " I'm a mail");
        }
    }
}
