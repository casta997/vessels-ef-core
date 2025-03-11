using _003_DI.IGlobalServices;
using _003_DI.IPersonalServices;

namespace _003_DI.Services;

internal class Notification(INotificationFactory notificationFactory)
{
    public void Notify<T>(string message) where T : INotificationService
    {
        var notification =  notificationFactory.GetService<T>();
        notification.Send(message);
    }
}
