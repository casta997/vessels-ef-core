using NotificationV2.Services;

namespace NotificationV2.Interfaces
{
    public interface INotificationService
    {
        string Send(string msg, string typeOfService);
    }
}
