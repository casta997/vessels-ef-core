namespace NotificationV2.Interfaces
{
    public interface IFactoryService
    {
        ISender TypeOfMessage(string typeOfService);
    }
}
