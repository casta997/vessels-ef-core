using DI_webApiNotification_001.EnumClasses;

namespace DI_webApiNotification_001.Interfaces.Entities;

public interface IFactoryNotification
{
    ISender TypeNotification(ETypeNotification typeNotification);
}