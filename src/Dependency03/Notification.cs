using Dependency03.Interfaces;

namespace Dependency03
{
    public class Notification(INotificationFactory notificationFactory)
    {
        public void Notify<T>(string message) where T : INotificationService
        {
            var notification = notificationFactory.GetService<T>();
            notification.Send(message);
        }
    }
}
