using CarRentalApplication.Entities;

namespace CarRentalApplication.IServices;

public interface ICarService
{
    IEnumerable<Car> GetAll();

    Car GetById(long id);
}
