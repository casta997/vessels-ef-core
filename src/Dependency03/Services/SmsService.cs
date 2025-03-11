using Dependency03.Interfaces;

namespace Dependency03.Services
{
    public class SmsService : INotificationService
    {
        public void Send(string msg)
        {
            Console.WriteLine(msg + " I'm a sms");
        }
    }
}
