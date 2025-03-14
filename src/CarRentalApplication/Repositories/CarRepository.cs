using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.IRepositories;
using CarRentalApplication.POCO;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Repositories;

public class CarRepository(CarRentalContext carRentalContext) : ICarRepository
{
    private readonly DbSet<Car> _carContext = carRentalContext.Cars;
    public IEnumerable<Car> GetAll()
    {
        return _carContext.ToList();
    }

    public Car GetById(long id)
    {
        return _carContext.Find(id);
    }

    public Car GetByLicensePlate(string LicensePlate)
    {
        return _carContext.FirstOrDefault(c => c.LicensePlate.Equals(LicensePlate));
    }

    public Car Add(CarPoco carPoco)
    {
        Car car = new Car();
        car.LicensePlate = carPoco.LicensePlate;
        car.IsRented = false;
        _carContext.Add(car);
        carRentalContext.SaveChanges();
        return car;
    }

    public int UpdateIsRented(long carId, bool isRented)
    {
        Car carFound = GetById(carId);
        carFound.IsRented = isRented;
        return carRentalContext.SaveChanges();
    }

    public int Delete(Car car)
    {
        _carContext.Remove(car);
        return carRentalContext.SaveChanges();
    }

    public int Update(Car car, CarPoco carPoco)
    {
        car.LicensePlate = carPoco.LicensePlate;
        return carRentalContext.SaveChanges();
    }
}
