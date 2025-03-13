using CarRentalApplication.Entities;
using CarRentalApplication.POCO;

namespace CarRentalApplication.IServices;

public interface ICarService
{
    IEnumerable<Car> GetAll();

    Car GetById(long id);
    Car Add(CarPoco car);
    Car DeleteById(long carId);
}
