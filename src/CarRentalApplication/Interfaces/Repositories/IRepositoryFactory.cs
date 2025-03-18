using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Repositories;

public interface IRepositoryFactory
{
    T GetService<T>() where T : ICommonRepository;
}
