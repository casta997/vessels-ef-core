using CarRentalApplication.Dto;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;

namespace CarRentalApplication.Interfaces.Services;

public interface ICustomerService
{
    //IEnumerable<Customer> GetAll();
    IEnumerable<IModel> GetAll<T>() where T : IModel;
    Customer GetById(long id);
    Customer Add(CustomerPoco customer);
    Customer DeleteById(long id);
    Customer Update(long customerId, CustomerPoco customerPoco);
}
