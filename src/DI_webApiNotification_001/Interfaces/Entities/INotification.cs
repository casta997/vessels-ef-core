using DI_webApiNotification_001.EnumClasses;

namespace DI_webApiNotification_001.Interfaces.Entities;

public interface INotification
{
    string Send(string msg, ETypeNotification typeNotification);
}
