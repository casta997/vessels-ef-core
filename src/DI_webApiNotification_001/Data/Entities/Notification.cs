using DI_webApiNotification_001.EnumClasses;
using DI_webApiNotification_001.Interfaces.Entities;

namespace DI_webApiNotification_001.Data.Entities;

public class Notification(IFactoryNotification factory) : INotification
{
    public string Send(string msg, ETypeNotification typeNotification)
    {
        var messageNotification = factory.TypeNotification(typeNotification);
        return messageNotification.Send(msg);
        /*
        switch (typeNotification)
        {
            case "email":
                
                return email.Send(msg);
            case "push":
                return push.Send(msg);
            case "sms":
                return sms.Send(msg);
            default:
                throw new Exception();

        }
        */
    }
}
