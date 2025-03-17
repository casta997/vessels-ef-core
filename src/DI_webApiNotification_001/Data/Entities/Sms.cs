using DI_webApiNotification_001.Interfaces.Entities;

namespace DI_webApiNotification_001.Data.Entities;

public class Sms : ISms
{
    public string Send(string msg)
    {
        return $"{msg} - by Sms";
    }
}
