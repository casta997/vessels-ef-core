using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces.Repositories;

public interface IRentalRepository : ICommonRepository
{
    int RentCar(long carId, long customerId, DateTime rentalDate);
    int UpdateRental(Rental rentalToUpdate, DateTime returnDate);
    Rental GetByLicensePlate(long carId);
}
