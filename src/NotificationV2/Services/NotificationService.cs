using NotificationV2.Interfaces;

namespace NotificationV2.Services
{
    public class NotificationService(IFactoryService factoryService) : INotificationService
    {
        public string Send(string msg, string typeOfService)
        {
            var vai = factoryService.TypeOfMessage(typeOfService);
            var hola = vai.Send(msg);
            return hola;
        }
    }
}
