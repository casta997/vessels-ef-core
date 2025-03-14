using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces;
using CarRentalApplication.Request;

namespace CarRentalApplication.Services
{
    public class RentalService(CarRentalContext carContext) : IRentalService
    {
        public List<Rental> GetAll()
        {
            List<Rental> allRentals = carContext.Rentals.ToList();
            return allRentals;
        }

        public Rental GetById(long id)
        {
            var rentalWithId = carContext.Rentals.FirstOrDefault(r => r.Id == id);
            return rentalWithId;
        }

        public void RentCar(RentalRequest rentalRequest)
        {
            var findCar = carContext.Cars.FirstOrDefault(c=>c.LicensePlate == rentalRequest.LicensePlate);
            var findCustomer = carContext.Customers.Find(rentalRequest.CustomerId);

            if (findCustomer == null)
            {
                return;
            }
            
            if (findCar != null && !findCar.IsRented)//we can rent only cars that aren't already rented by someone else
            {
                Rental newRental = new() { CustomerId = rentalRequest.CustomerId, CarId = findCar.Id, RentalDate = rentalRequest.RentalDate };
                findCar.IsRented = true;
                carContext.Rentals.Add(newRental);
                carContext.SaveChanges();
            }
        }

        public void ReturnCar(ReturnRequest returnRequest)
        {
            var findCar = carContext.Cars.FirstOrDefault(c => c.LicensePlate == returnRequest.LicensePlate);

            if (findCar == null)
            {
                return;
            }

            var findRental = carContext.Rentals.FirstOrDefault(r => r.CarId == findCar.Id && r.ReturnDate == null);

            if (findRental == null && findRental.ReturnDate != null) //we can return only cars that aren't already been returned (if the user needs to modify a return he can use the put request)  
            {
                return;
            }

            if (returnRequest.ReturnDate > findRental.RentalDate)
            {
                findRental.ReturnDate = returnRequest.ReturnDate;
                findCar.IsRented = false;
                carContext.SaveChanges();
            }
        }

        public void Update(long id, long carId, long customerId, DateTime rentalDate, DateTime? returnDate)
        {
            var findRental = carContext.Rentals.FirstOrDefault(r => r.Id == id);
            
            if (findRental == null)
            {
                return;
            }
            
            var findCar = carContext.Cars.Where(c => c.Id == carId && (c.IsRented == false || c.Id == findRental.CarId)).FirstOrDefault(c => c.Id == carId);
            
            if (findCar == null)
            {
                return;
            }
            
            var findCustomer = carContext.Customers.FirstOrDefault(cu => cu.Id == customerId);
            
            if (findCustomer == null)
            {
                return;
            }
            
            if (findRental == null && findCar == null && findCustomer == null)
            {
                return;
            }
            
            if (returnDate > rentalDate || returnDate == null)
            {
                findRental.RentalDate = rentalDate;
                findRental.ReturnDate = returnDate;
                findCar.IsRented = (returnDate == null)? true : false;
                findRental.CarId = carId;
                findRental.CustomerId = customerId;

                carContext.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var findRent = carContext.Rentals.FirstOrDefault(r => r.Id == id);

            if (findRent == null)
            {
                return;
            }

            var findCar = carContext.Cars.FirstOrDefault(c => c.Id == findRent.CarId);

            if(findRent.ReturnDate == null)
            {
                findCar.IsRented = false;
            }

            carContext.Rentals.Remove(findRent);
            carContext.SaveChanges();
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
