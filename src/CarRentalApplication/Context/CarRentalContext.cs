using CarRentalApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Context;

public class CarRentalContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Car> Cars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rental { get; set; }

    public CarRentalContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _connectionString = configuration.GetConnectionString("CarRentalConnection") ??
            throw new InvalidOperationException("Connection string 'CarRentalConnection'" +
            " not found.");

        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}
