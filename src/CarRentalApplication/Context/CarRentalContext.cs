using CarRentalApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Context;

public class CarRentalContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rental { get; set; }

    public CarRentalContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
