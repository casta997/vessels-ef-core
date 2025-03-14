using CarRentalApplication.Entities;
using CarRentalApplication.POCO;

namespace CarRentalApplication.IRepositories;

public interface ICarRepository
{
    IEnumerable<Car> GetAll();
    Car GetById(long id);
    Car GetByLicensePlate(string LicensePlate);
    Car Add(CarPoco car);
    int UpdateIsRented(long carId, bool isRented);
    int Delete(Car car);
    int Update(Car car, CarPoco carPoco);
}
