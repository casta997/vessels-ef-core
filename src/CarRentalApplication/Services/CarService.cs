using CarRentalApplication.Dto.Request;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;
using CarRentalApplication.Interfaces.Repositories;
using CarRentalApplication.Interfaces.Services;

namespace CarRentalApplication.Services;

public class CarService(IRepositoryFactory repositoryFactory) : ICarService
{
    private readonly ICarRepository _carRepository = repositoryFactory.GetService<ICarRepository>();

    public IEnumerable<IModel> GetAll()
    {
        return _carRepository.GetAll();
    }

    public Car? GetById(long id)
    {
        return (Car)_carRepository.GetById(id);
    }

    public Car?  Add(CarModel carRequest)
    {
        try
        {
            if (String.IsNullOrEmpty(carRequest.LicensePlate.Trim()))
            {
                return null;
            }

            Car car = GetByLicensePlate(carRequest.LicensePlate);

            if (car is not null)
            {
                return null;
            }

            carRequest.LicensePlate = carRequest.LicensePlate.Trim();

            if (_carRepository.Add(carRequest) > 0)
            {
                return GetByLicensePlate(carRequest.LicensePlate);
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
    public Car? Update(long carId, CarModel carModel)
    {
        Car car = GetById(carId);
        if (car is not null)
        {
            var licensePlatePoco = carModel.LicensePlate.Trim();
            if (licensePlatePoco.Length > 0 && licensePlatePoco != car.LicensePlate)
            {
                _carRepository.Update(car, carModel);
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
