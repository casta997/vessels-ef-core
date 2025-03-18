using CarRentalApplication.Interfaces.Entities;
using CarRentalApplication.Interfaces.Repositories;

namespace CarRentalApplication.Repositories;

public class RepositoryFactory(IServiceProvider serviceProvider) : IRepositoryFactory
{
    public T GetService<T>() where T : ICommonRepository
    {
        return serviceProvider.GetService<T>();
    }
}
