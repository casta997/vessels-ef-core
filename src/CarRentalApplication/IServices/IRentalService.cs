using CarRentalApplication.Entities;
using CarRentalApplication.POCO;

namespace CarRentalApplication.IServices;

public interface IRentalService
{
    IEnumerable<Rental> GetAll();
    Rental GetById(long id);
    void RentCar(RentalRequest request);
    void ReturnCar(ReturnRequest request);
    Car GetCarByLicensePlate(string LicensePlate);
    Customer GetCustomerById(long CustomerId);
    Rental GetByLicensePlate(string licensePlate);
}
