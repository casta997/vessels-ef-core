using DI_webApiNotification_001.Interfaces.Entities;

namespace DI_webApiNotification_001.Data.Entities;

public class Email : IEmail
{
    public string Send(string msg)
    {
        return $"{msg} - by Email";
    }
}
