using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.IRepositories;
using CarRentalApplication.POCO;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Repositories;

public class CustomerRepository(CarRentalContext carRentalContext, Customer customer) : ICustomerRepository
{
    private readonly DbSet<Customer> _customers = carRentalContext.Customers;
    public IEnumerable<Customer> GetAll()
    {
        return _customers.ToList();
    }

    public Customer GetById(long id)
    {
        return _customers.Find(id);
    }

    public Customer Add(CustomerPoco customerPoco)
    {
        customer.Name = customerPoco.Name;
        _customers.Add(customer);
        carRentalContext.SaveChanges();
        return customer;
    }
}
