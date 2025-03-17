using NotificationV2.Interfaces;

namespace NotificationV2.Services
{
    public class EmailService : ISender
    {
        public string Send(string msg)
        {
            var message = msg + "I'm a mail";
            return message;
        }
    }
}
