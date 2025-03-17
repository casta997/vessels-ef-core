using NotificationV2.Interfaces;

namespace NotificationV2.Services
{
    public class SmsService : ISender
    {
        public string Send(string msg)
        {
            var message = msg + "I'm a sms";
            return message;
        }
    }
}
