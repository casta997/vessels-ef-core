using CarRentalApplication.Dto.Request;
using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces.Repositories;

public interface ICarRepository : ICommonRepository
{
    Car GetByLicensePlate(string LicensePlate);
    int UpdateIsRented(long carId, bool isRented);
    int Delete(Car car);
    int Update(Car car, CarModel carPoco);
    int Add(CarModel d);
}
