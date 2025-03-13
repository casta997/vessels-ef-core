using CarRentalApplication.Entities;
using CarRentalApplication.IRepositories;
using CarRentalApplication.IServices;
using CarRentalApplication.POCO;
using CarRentalApplication.Repositories;

namespace CarRentalApplication.Services;

public class CarService(ICarRepository carRepository) : ICarService
{
    private readonly ICarRepository _carRepository = carRepository;
    public IEnumerable<Car> GetAll()
    {
        return _carRepository.GetAll();
    }

    public Car GetById(long id)
    {
        return _carRepository.GetById(id);
    }

    public Car Add(CarPoco car) {
        try
        {
            if (String.IsNullOrEmpty(car.LicensePlate.Trim()))
                return null;

            car.LicensePlate = car.LicensePlate.Trim();

            return _carRepository.Add(car);
        }
        catch { return null; }
    }

    public Car DeleteById(long carId)
    {
        Car car = GetById(carId);
        if (car is not null)
            _carRepository.Delete(car);
        return car;
    }
}
