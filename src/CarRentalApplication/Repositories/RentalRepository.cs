using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Repositories;

public class RentalRepository(CarRentalContext carRentalContext) : IRentalRepository
{
    private readonly DbSet<Rental> _rentalContext = carRentalContext.Rental;
    public IEnumerable<Rental> GetAll()
    {
        return _rentalContext.ToList();
    }

    public Rental GetById(long id)
    {
        return _rentalContext.Find(id);
    }

    public int RentCar(long carId, long customerId, DateTime rentalDate)
    {
        var rental = new Rental();
        rental.CarId = carId;
        rental.CustomerId = customerId;
        rental.RentalDate = rentalDate;
        _rentalContext.Add(rental);
        return carRentalContext.SaveChanges();
    }

    public int UpdateRental(Rental rentalToUpdate, DateTime returnDate)
    {
        rentalToUpdate.ReturnDate = returnDate;
        return carRentalContext.SaveChanges();
    }

    public Rental GetByLicensePlate(long carId)
    {
        return _rentalContext.FirstOrDefault(rental => rental.CarId == carId);
    }
}
