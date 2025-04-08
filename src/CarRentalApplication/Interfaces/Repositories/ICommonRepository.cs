using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Repositories;

public interface ICommonRepository
{
    IEnumerable<IModel> GetAll();
    IModel GetById(long id);
}