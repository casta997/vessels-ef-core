using NotificationV2.Interfaces;

namespace NotificationV2.Services
{
    public class PushService : ISender
    {
        public string Send(string msg)
        {
            var message = msg + "I'm a push";
            return message;
        }
    }
}
