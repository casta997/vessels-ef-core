using Notification.Interfaces;

namespace Notification.Services
{
    public class PushService : IPushService
    {
        public string send(string msg)
        {
            string push = msg + " I'm a push";
            return push;
        }
    }
}
