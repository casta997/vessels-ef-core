using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CarRentalApplication.Services
{
    public class RentalService(CarRentalContext carContext) : IRentalService
    {
        public IEnumerable<Rental> GetAll()
        {
            var allRentals = carContext.Rentals;
            return allRentals;
        }

        public Rental GetById(long id)
        {
            var rentalWithId = carContext.Rentals.FirstOrDefault(r => r.Id == id);
            return rentalWithId;
        }

        public void RentCar(long customerId, string licensePlate, DateTime rentalDate)
        {
            var findCar = carContext.Cars.FirstOrDefault(c=>c.LicensePlate == licensePlate);
            var findCustomer = carContext.Customers.Find(customerId);

            if (findCustomer != null)
            {
                if (findCar != null)
                {
                    if (findCar.IsRented != true)//we can rent only cars that aren't already rented by someone else
                    {
                        Rental newRental = new() { CustomerId = customerId, CarId = findCar.Id, RentalDate = rentalDate };
                        findCar.IsRented = true;
                        carContext.Rentals.Add(newRental);
                        carContext.SaveChanges();
                    }
                }
            }
        }

        public void ReturnCar(string licensePlate, DateTime returnDate)
        {
            var findCar = carContext.Cars.FirstOrDefault(c => c.LicensePlate == licensePlate);

            if(findCar != null)
            {
                var findRental = carContext.Rentals.FirstOrDefault(r => r.CarId == findCar.Id && r.ReturnDate == null);


                if (findRental != null && findRental.ReturnDate == null) //if we want to return only car that aren't already been returned (if the user needs to modify a return he ca nuse the put request)  
                {
                    if (returnDate > findRental.RentalDate)
                    {
                        findRental.ReturnDate = returnDate;
                        findCar.IsRented = false;
                        carContext.SaveChanges();
                    }
                }
            }
        }

        public void UpdateObj(long id, long carId, long customerId, DateTime rentalDate, DateTime? returnDate)
        {
            var findRental = carContext.Rentals.FirstOrDefault(r => r.Id == id);
            if (findRental != null)
            {
                var findCar = carContext.Cars.Where(c => c.Id == carId && (c.IsRented == false || c.Id == findRental.CarId)).FirstOrDefault(c => c.Id == carId);
                if (findCar != null)
                {
                    var findCustomer = carContext.Customers.FirstOrDefault(cu => cu.Id == customerId);
                    if (findCustomer != null)
                    {
                        if (findRental != null && findCar != null && findCustomer != null)
                        {
                            if (returnDate > rentalDate || returnDate == null)
                            {
                                findRental.RentalDate = rentalDate;
                                findRental.ReturnDate = returnDate;
                                findRental.CarId = carId;
                                findRental.CustomerId = customerId;

                                if (returnDate == null)
                                {
                                    findCar.IsRented = true;
                                }
                                else
                                {
                                    findCar.IsRented = false;
                                }

                                carContext.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        public void DeleteObj(long id)
        {
            var findRent = carContext.Rentals.FirstOrDefault(r => r.Id == id);

            if(findRent != null)
            {
                var findCar = carContext.Cars.FirstOrDefault(c => c.Id == findRent.CarId);

                if(findRent.ReturnDate == null)
                {
                    findCar.IsRented = false;
                }

                carContext.Rentals.Remove(findRent);
                carContext.SaveChanges();
            }
        }

        /*
        public void RentCar2(long carId, long customerId)
        {
            var findCar = carContext.Cars.Find(carId);
            var findCustomer = carContext.Customers.Find(customerId);

            if (findCar != null && findCustomer != null)
            {
                Rental newRental = new() { CustomerId = customerId, CarId = carId, RentalDate = DateTime.Now };
                findCar.IsRented = true;
                carContext.Rentals.Add(newRental);
                carContext.SaveChanges();
            }
        }

        public void RentCar(Car car, Customer customer)
        {
            var findCar = carContext.Cars.Find(car);
            var findCustomer = carContext.Customers.Find(customer);

            if (findCar != null && findCustomer != null)
            {
                Rental newRental = new() { CustomerId = customer.Id, CarId = car.Id, RentalDate = DateTime.Now };
                findCar.IsRented = true;
                carContext.Rentals.Add(newRental);
                carContext.SaveChanges();
            }
        }
        */
    }
}
