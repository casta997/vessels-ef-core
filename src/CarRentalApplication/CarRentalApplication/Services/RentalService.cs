using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces;
using CarRentalApplication.Request;

namespace CarRentalApplication.Services
{
    public class RentalService : ServiceBase, IRentalService
    {
        public RentalService(CarRentalContext carContext) : base(carContext)
        {
        }

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
            var findCar = carContext.Cars.FirstOrDefault(c => c.LicensePlate == rentalRequest.LicensePlate);
            var findCustomer = carContext.Customers.Find(rentalRequest.CustomerId);

            if (findCustomer == null)
            {
                return;
            }

            //we can rent only cars that aren't already rented by someone else
            if (findCar != null && !findCar.IsRented)
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

            //we can return only cars that aren't already been returned (if the user needs to modify a return he can use the put request)
            if (findRental == null && findRental.ReturnDate != null)
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

        public void Update(UpdateRentalRequest updateRentalRequest)
        {
            var findRental = carContext.Rentals.FirstOrDefault(r => r.Id == updateRentalRequest.RentalId);

            if (findRental == null)
            {
                return;
            }

            var findCar = carContext.Cars.FirstOrDefault(c => c.Id == updateRentalRequest.CarId && (c.IsRented == false || c.Id == findRental.CarId));

            if (findCar == null)
            {
                return;
            }

            var findCustomer = carContext.Customers.FirstOrDefault(cu => cu.Id == updateRentalRequest.CustomerId);

            if (findCustomer == null)
            {
                return;
            }

            if (findRental == null && findCar == null && findCustomer == null)
            {
                return;
            }

            if (updateRentalRequest.ReturnDate > updateRentalRequest.RentalDate || updateRentalRequest.ReturnDate == null)
            {
                findRental.RentalDate = updateRentalRequest.RentalDate;
                findRental.ReturnDate = updateRentalRequest.ReturnDate;
                findCar.IsRented = (updateRentalRequest.ReturnDate == null) ? true : false;
                findRental.CarId = updateRentalRequest.CarId;
                findRental.CustomerId = updateRentalRequest.CustomerId;

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

            if (findRent.ReturnDate == null)
            {
                findCar.IsRented = false;
            }

            carContext.Rentals.Remove(findRent);
            carContext.SaveChanges();
        }
    }
}
