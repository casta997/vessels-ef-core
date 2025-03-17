using Notification_Dependency.Interfaces;

namespace Notification_Dependency.Services
{
    public class PushService : IPushService
    {
        public void send(string msg)
        {
            Console.WriteLine(msg + " I'm a push");
        }
    }
}
