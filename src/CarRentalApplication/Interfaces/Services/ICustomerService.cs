using CarRentalApplication.Dto.Request;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Services;

public interface ICustomerService
{
    IEnumerable<IModel> GetAll();
    Customer GetById(long id);
    Customer Add(CustomerModel customer);
    Customer DeleteById(long id);
    Customer Update(long customerId, CustomerModel customerPoco);
}
