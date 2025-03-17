using DI_webApiNotification_001.Interfaces.Entities;

namespace DI_webApiNotification_001.Data.Entities;

public class Push : IPush
{
    public string Send(string msg)
    {
        return $"{msg} - by Push";
    }
}
