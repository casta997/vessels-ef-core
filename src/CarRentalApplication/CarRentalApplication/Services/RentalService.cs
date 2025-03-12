using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces;

namespace CarRentalApplication.Services
{
    public class RentalService : IRentalService
    {
        public IEnumerable<Rental> GetAll()
        {
            throw new NotImplementedException();
        }

        public Rental GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void RentCar(Car car, Customer customer)
        {
            throw new NotImplementedException();
        }

        public void ReturnCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
