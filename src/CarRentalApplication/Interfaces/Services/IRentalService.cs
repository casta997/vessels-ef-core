using CarRentalApplication.Dto;
using CarRentalApplication.Entities;

namespace CarRentalApplication.Interfaces.Services;

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
