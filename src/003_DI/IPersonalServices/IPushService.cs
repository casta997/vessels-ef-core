namespace _003_DI.IPersonalServices;

internal interface IPushService: INotificationService
{
    void Send(string message);
}
