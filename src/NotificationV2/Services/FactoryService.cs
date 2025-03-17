using NotificationV2.Interfaces;

namespace NotificationV2.Services
{
    public class FactoryService : IFactoryService
    {
        public ISender TypeOfMessage(string typeOfService)
        {
            switch (typeOfService)
            {
                case "email":
                    var email = new EmailService();
                    return email;
                case "sms":
                    var sms = new SmsService();
                    return sms;
                case "push":
                    var push = new PushService();
                    return push;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
