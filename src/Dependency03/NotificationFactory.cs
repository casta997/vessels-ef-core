using Dependency03.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dependency03
{
    public class NotificationFactory(IServiceProvider serviceProvider) : INotificationFactory
    {
        public T GetService<T>() where T : INotificationService
        {
            return serviceProvider.GetService<T>();
        }
    }
}
