using NotificationV2.Interfaces;

namespace NotificationV2.Services
{
    public class NotificationService(IFactoryService factoryService) : INotificationService
    {
        public string Send(string msg, string typeOfService)
        {
            var typeSend = factoryService.TypeOfMessage(typeOfService);
            var completeMessage = typeSend.Send(msg);
            return completeMessage;
        }
    }
}
