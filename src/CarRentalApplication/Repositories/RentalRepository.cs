using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;
using CarRentalApplication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Repositories;

public class RentalRepository : ContextBase, IRentalRepository
{
    private readonly CarRentalContext _context;
    private readonly DbSet<Rental> _rentalDb;

    public RentalRepository(CarRentalContext carRentalContext) : base(carRentalContext)
    {
        _context = _carRentalContext;
        _rentalDb = _carRentalContext.Rental;
    }

    public IEnumerable<IModel> GetAll()
    {
        return _rentalDb.ToList();
    }

    public Rental GetById(long id)
    {
        return _rentalDb.Find(id);
    }

    public int RentCar(long carId, long customerId, DateTime rentalDate)
    {
        var rental = new Rental();
        rental.CarId = carId;
        rental.CustomerId = customerId;
        rental.RentalDate = rentalDate;
        _rentalDb.Add(rental);
        return _context.SaveChanges();
    }

    public int UpdateRental(Rental rentalToUpdate, DateTime returnDate)
    {
        rentalToUpdate.ReturnDate = returnDate;
        return _context.SaveChanges();
    }

    public Rental GetByLicensePlate(long carId)
    {
        return _rentalDb.FirstOrDefault(rental => rental.CarId == carId);
    }
}
