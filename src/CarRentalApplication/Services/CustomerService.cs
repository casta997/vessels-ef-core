using CarRentalApplication.Entities;
using CarRentalApplication.IRepositories;
using CarRentalApplication.IServices;
using CarRentalApplication.POCO;

namespace CarRentalApplication.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    public IEnumerable<Customer> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public Customer GetById(long id)
    {
        return _customerRepository.GetById(id);
    }

    public Customer Add(CustomerPoco customer)
    {
        try
        {
            if (String.IsNullOrEmpty(customer.Name.Trim()))
                return null;

            customer.Name = customer.Name.Trim();

            return _customerRepository.Add(customer);
        }
        catch { return null; }
    }
}
