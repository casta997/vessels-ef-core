using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Repositories;

public interface ICommonRepository
{
    IEnumerable<IModel> GetAll<T>() where T : IModel;
}