using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Repositories;

public interface ICommonRepository<T> where T : ICommonRepository<T>
{
    IEnumerable<IModel> GetAll();
}