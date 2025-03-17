namespace CarRentalApplication.Interfaces.Repositories;

public interface ICommonFactoryRepositories
{
    T GetService<T>() where T : ICommonRepository;
}