using CarRentalApplication.Dto;
using CarRentalApplication.Dto.Request;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Services;

public interface IRentalService
{
    IEnumerable<IModel> GetAll();
    Rental GetById(long id);
    void RentCar(RentalCarModel request);
    void ReturnCar(ReturnCarRentedModel request);
    Car GetCarByLicensePlate(string LicensePlate);
    Customer GetCustomerById(long CustomerId);
    Rental GetByLicensePlate(string licensePlate);
}
