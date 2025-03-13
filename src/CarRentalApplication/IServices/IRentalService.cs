using CarRentalApplication.Entities;

namespace CarRentalApplication.IServices;

public interface IRentalService
{
    IEnumerable<Rental> GetAll();

    Rental GetById(long id);
}
