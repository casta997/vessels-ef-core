using CarRentalApplication.Entities;

namespace CarRentalApplication.IServices;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();
    Customer GetById(long id);
}
