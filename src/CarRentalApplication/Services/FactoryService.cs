using CarRentalApplication.IServices;

namespace CarRentalApplication.Services;

public class FactoryService(ServiceProvider serviceProvider) : IFactoryService
{
    T IFactoryService.GetService<T>()
    {
        return serviceProvider.GetService<T>();
    }
}
