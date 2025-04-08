using CarRentalApplication.Dto.Request;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Services;

public interface ICarService
{
    IEnumerable<IModel> GetAll();

    Car GetById(long id);
    Car Add(CarModel car);
    Car DeleteById(long carId);
    Car Update(long carId, CarModel car);
    Car GetByLicensePlate(string licensePlate);
}
