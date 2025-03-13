using CarRentalApplication.Entities;

namespace CarRentalApplication.IRepositories;

public interface IRentalRepository
{
    IEnumerable<Rental> GetAll();
    Rental GetById(long id);
    int RentCar(long carId, long customerId, DateTime rentalDate);
    int UpdateRental(Rental rentalToUpdate, DateTime returnDate);
    Rental GetByLicensePlate(long carId);
}
