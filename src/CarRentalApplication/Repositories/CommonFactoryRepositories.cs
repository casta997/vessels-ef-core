using CarRentalApplication.Interfaces.Repositories;

namespace CarRentalApplication.Repositories;

public class CommonFactoryRepositories(IServiceProvider serviceProvider): ICommonFactoryRepositories
{
    public T GetService<T>() where T : ICommonRepository<T>
    {

        return serviceProvider.GetService<T>();
    }
}
