namespace Dependency03.Interfaces
{
    public interface INotificationFactory
    {
        T GetService<T>() where T : INotificationService;
    }
}
