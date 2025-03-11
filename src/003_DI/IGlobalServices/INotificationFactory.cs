using _003_DI.IPersonalServices;

namespace _003_DI.IGlobalServices;

internal interface INotificationFactory
{
    T GetService<T>() where T : INotificationService;
}
