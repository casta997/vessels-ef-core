namespace _003_DI.IPersonalServices;

internal interface ISmsService: INotificationService
{
    void Send(string message);
}
