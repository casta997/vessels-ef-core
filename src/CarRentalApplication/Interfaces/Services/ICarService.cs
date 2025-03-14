using CarRentalApplication.Dto;
using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces.Services;

public interface ICarService
{
    IEnumerable<Car> GetAll();

    Car GetById(long id);
    Car Add(CarPoco car);
    Car DeleteById(long carId);
    Car Update(long carId, CarPoco car);
    Car GetByLicensePlate(string licensePlate);
}
