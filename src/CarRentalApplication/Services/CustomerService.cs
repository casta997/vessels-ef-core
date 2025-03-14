using CarRentalApplication.Entities;
using CarRentalApplication.IRepositories;
using CarRentalApplication.IServices;
using CarRentalApplication.POCO;
using CarRentalApplication.Repositories;

namespace CarRentalApplication.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    public IEnumerable<Customer> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public Customer? GetById(long id)
    {
        return _customerRepository.GetById(id);
    }

    public Customer? Add(CustomerPoco customer)
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

    public Customer? DeleteById(long id)
    {
        Customer car = GetById(id);
        if (car is not null)
            _customerRepository.Delete(car);
        return car;
    }

    public Customer? Update(long customerId, CustomerPoco customerPoco)
    {
        Customer customer = GetById(customerId);
        if (customer is not null)
        {
            var namePoco = customerPoco.Name.Trim();
            if (namePoco.Length > 0 && namePoco != customer.Name)
            {
                _customerRepository.Update(customer, customerPoco);
            }
        }
        return customer;
    }
}
