namespace _003_DI.IPersonalServices;

internal interface IEmailService: INotificationService
{
    void Send(string message);
}
