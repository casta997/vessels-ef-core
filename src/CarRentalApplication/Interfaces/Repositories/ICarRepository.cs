using CarRentalApplication.Dto;
using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces.Repositories;

public interface ICarRepository : ICommonRepository
{
    //IEnumerable<Car> GetAll();
    Car GetById(long id);
    Car GetByLicensePlate(string LicensePlate);
    Car Add(CarPoco car);
    int UpdateIsRented(long carId, bool isRented);
    int Delete(Car car);
    int Update(Car car, CarPoco carPoco);
}
