using CarRentalApplication.Dto;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;
using CarRentalApplication.Interfaces.Repositories;
using CarRentalApplication.Interfaces.Services;

namespace CarRentalApplication.Services;

public class CarService(ICarRepository carRepository) : ICarService
{
    private readonly ICarRepository _carRepository = carRepository;

    public IEnumerable<IModel> GetAll<T>() where T : IModel
    {
        return _carRepository.GetAll<T>();
    }

    public Car? GetById(long id)
    {
        return _carRepository.GetById(id);
    }

    public Car? Add(CarPoco carPoco)
    {
        try
        {
            if (String.IsNullOrEmpty(carPoco.LicensePlate.Trim()))
            {
                return null;
            }

            Car car = GetByLicensePlate(carPoco.LicensePlate);

            if (car is null)
            {
                carPoco.LicensePlate = carPoco.LicensePlate.Trim();
                return _carRepository.Add(carPoco);
            }

            return null;
        }
        catch { return null; }
    }

    public Car? DeleteById(long carId)
    {
        Car car = GetById(carId);
        if (car is not null)
        {
            _carRepository.Delete(car);
        }
        return car;
    }

    public Car? Update(long carId, CarPoco carPoco)
    {
        Car car = GetById(carId);
        if (car is not null)
        {
            var licensePlatePoco = carPoco.LicensePlate.Trim();
            if (licensePlatePoco.Length > 0 && licensePlatePoco != car.LicensePlate)
            {
                _carRepository.Update(car, carPoco);
            }
        }
        return car;
    }

    public Car? GetByLicensePlate(string licensePlate)
    {
        if (String.IsNullOrEmpty(licensePlate.Trim()))
        {
            return null;
        }

        return _carRepository.GetByLicensePlate(licensePlate);
    }
}
