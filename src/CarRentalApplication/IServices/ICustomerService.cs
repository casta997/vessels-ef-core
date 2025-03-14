using CarRentalApplication.Entities;
using CarRentalApplication.POCO;

namespace CarRentalApplication.IServices;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();
    Customer GetById(long id);
    Customer Add(CustomerPoco customer);
    Customer DeleteById(long id);
    Customer Update(long customerId, CustomerPoco customerPoco);
}
