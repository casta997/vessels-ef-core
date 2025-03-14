using CarRentalApplication.Interfaces.Services;

namespace CarRentalApplication.Services;

public class FactoryService(ServiceProvider serviceProvider) : IFactoryService
{
    public T GetService<T>()
    {
        return serviceProvider.GetService<T>();
    }
}
