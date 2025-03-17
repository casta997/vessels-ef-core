using Notification.Interfaces;

namespace Notification.Services
{
    public class SmsService : ISmsService
    {
        public string send(string msg)
        {
            string sms = msg + " I'm a sms";
            return sms;
        }
    }
}
