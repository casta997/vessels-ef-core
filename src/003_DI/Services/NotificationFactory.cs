using _003_DI.IGlobalServices;
using _003_DI.IPersonalServices;
using Microsoft.Extensions.DependencyInjection;

namespace _003_DI.Services;

internal class NotificationFactory(IServiceProvider serviceProvider) : INotificationFactory
{
    public T GetService<T>() where T : INotificationService
    {
        return serviceProvider.GetService<T>();
    }
}
