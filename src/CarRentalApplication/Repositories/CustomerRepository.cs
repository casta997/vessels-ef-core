using CarRentalApplication.Context;
using CarRentalApplication.Dto;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Repositories;

public class CustomerRepository : ContextBase, ICustomerRepository
{
    private readonly CarRentalContext _context;
    private readonly DbSet<Customer> _customerDb;

    public CustomerRepository(CarRentalContext carRentalContext) : base(carRentalContext)
    {
        _context = _carRentalContext;
        _customerDb = _carRentalContext.Customers;
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customerDb.ToList();
    }

    public Customer GetById(long id)
    {
        return _customerDb.Find(id);
    }

    public Customer Add(CustomerPoco customerPoco)
    {
        var customer = new Customer();
        customer.Name = customerPoco.Name;
        _customerDb.Add(customer);
        _context.SaveChanges();
        return customer;
    }

    public int Delete(Customer customer)
    {
        _customerDb.Remove(customer);
        return _context.SaveChanges();
    }

    public int Update(Customer customer, CustomerPoco customerPoco)
    {
        customer.Name = customerPoco.Name;
        return _context.SaveChanges();
    }
}
