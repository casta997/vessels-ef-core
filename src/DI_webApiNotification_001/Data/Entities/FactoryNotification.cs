using DI_webApiNotification_001.EnumClasses;
using DI_webApiNotification_001.Interfaces.Entities;

namespace DI_webApiNotification_001.Data.Entities;

public class FactoryNotification: IFactoryNotification
{
    public ISender TypeNotification (ETypeNotification typeNotification)
    {
        switch (typeNotification)
        {
            case ETypeNotification.Email:
                var email = new Email ();
                return email;
            case ETypeNotification.Push:
                var push = new Push ();
                return push;
            case ETypeNotification.Sms:
                var sms = new Sms ();
                return sms;
            default:
                throw new NotImplementedException();

        }
    }
}
