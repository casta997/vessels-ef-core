using CarRentalApplication.Dto;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Repositories;
using CarRentalApplication.Interfaces.Services;

namespace CarRentalApplication.Services;

public class RentalService(IRentalRepository rentalRepository, ICarRepository carRepository, ICustomerRepository customerRepository) : IRentalService
{
    private readonly IRentalRepository _rentalRepository = rentalRepository;
    private readonly ICarRepository _carRepository = carRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;
    public IEnumerable<Rental> GetAll()
    {
        return _rentalRepository.GetAll();
    }

    public Rental GetById(long id)
    {
        return _rentalRepository.GetById(id);
    }

    public void RentCar(RentalRequest request) {
        var car = GetCarByLicensePlate(request.LicensePlate);
        var customer = GetCustomerById(request.CustomerId);

        if (car is not null && customer is not null && !car.IsRented)
        {
            if (_rentalRepository.RentCar(car.Id, customer.Id, request.RentalDate) > 0)
            {
                _carRepository.UpdateIsRented(car.Id, true);
            }
        }
    }
    public void ReturnCar(ReturnRequest request) {
        var car = GetCarByLicensePlate(request.LicensePlate);

        if (car is not null && car.IsRented)
        {
            Rental rental = GetByLicensePlate(car.LicensePlate);

            if (rental.RentalDate < request.ReturnDate && _rentalRepository.UpdateRental(rental, request.ReturnDate) > 0)
            {
                _carRepository.UpdateIsRented(car.Id, false);
            }
        }

    }

    public Rental? GetByLicensePlate(string licensePlate)
    {
        if (String.IsNullOrEmpty(licensePlate.Trim()))
        {
            return null;
        }

        var car = GetCarByLicensePlate(licensePlate);

        return _rentalRepository.GetByLicensePlate(car.Id);
    }

    
    public Car? GetCarByLicensePlate(string licensePlate) {
        if (String.IsNullOrEmpty(licensePlate.Trim()))
        {
            return null;
        }

        return _carRepository.GetByLicensePlate(licensePlate);
    }
    
    public Customer? GetCustomerById(long customerId) {
        return _customerRepository.GetById(customerId);
    }
}
