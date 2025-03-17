using CarRentalApplication.Context;
using CarRentalApplication.Dto;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Repositories;

public class CarRepository : ContextBase, ICarRepository, ICommonRepository<Car>
{
    private readonly CarRentalContext _context;
    private readonly DbSet<Car> _carDb;

    public CarRepository(CarRentalContext carRentalContext) : base(carRentalContext)
    {
        _context = _carRentalContext;
        _carDb = _carRentalContext.Cars;
    }

    public IEnumerable<Car> GetAll()
    {
        return _carDb.ToList();
    }

    public Car GetById(long id)
    {
        return _carDb.Find(id);
    }

    public Car GetByLicensePlate(string LicensePlate)
    {
        return _carDb.FirstOrDefault(c => c.LicensePlate.Equals(LicensePlate));
    }

    public Car Add(CarPoco carPoco)
    {
        Car car = new Car();
        car.LicensePlate = carPoco.LicensePlate;
        car.IsRented = false;
        _carDb.Add(car);
        _context.SaveChanges();
        return car;
    }

    public int UpdateIsRented(long carId, bool isRented)
    {
        Car carFound = GetById(carId);
        carFound.IsRented = isRented;
        return _context.SaveChanges();
    }

    public int Delete(Car car)
    {
        _carDb.Remove(car);
        return _context.SaveChanges();
    }

    public int Update(Car car, CarPoco carPoco)
    {
        car.LicensePlate = carPoco.LicensePlate;
        return _context.SaveChanges();
    }
}
