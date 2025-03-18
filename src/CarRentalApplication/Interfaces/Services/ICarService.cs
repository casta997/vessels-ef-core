using CarRentalApplication.Dto;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Services;

public interface ICarService
{
    IEnumerable<IModel> GetAll();

    Car GetById(long id);
    Car Add(CarPoco car);
    Car DeleteById(long carId);
    Car Update(long carId, CarPoco car);
    Car GetByLicensePlate(string licensePlate);
}
