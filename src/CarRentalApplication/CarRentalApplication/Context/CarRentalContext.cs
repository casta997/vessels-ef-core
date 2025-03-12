using CarRentalApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Context
{
    public class CarRentalContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var initialCars = new[]
            {
                new Car { Id = 1, IsRented = true, LicensePlate = "ABC-1234" },
                new Car { Id = 2, IsRented = false, LicensePlate = "XYZ-5678" },
                new Car { Id = 3, IsRented = false, LicensePlate = "JKL-9101" },
                new Car { Id = 4, IsRented = true, LicensePlate = "MNO-2345" }
            };

            modelBuilder.Entity<Car>().HasData(initialCars);

            var initialCustomers = new[]
            {
                new Customer { Id = 1, Name = "Giorgio Tomaino" },
                new Customer { Id = 2, Name = "Michele Presti" },
                new Customer { Id = 3, Name = "Erica Pinto" },
            };

            modelBuilder.Entity<Customer>().HasData(initialCustomers);

            var initialRentals = new[]
            {
                new Rental { Id = 1, CarId = 1, CustomerId = 2, RentalDate = new DateTime(2025, 3, 1, 14, 0, 0), ReturnDate = new DateTime(2025, 3, 6, 14, 0, 0)},
                new Rental { Id = 2, CarId = 2, CustomerId = 1, RentalDate = new DateTime(2025, 1, 5, 09, 0, 0), ReturnDate = null},
                new Rental { Id = 3, CarId = 1, CustomerId = 3, RentalDate = new DateTime(2024, 12, 09, 12, 0, 0), ReturnDate = new DateTime(2024, 12, 12, 20, 0, 0)},
            };

            modelBuilder.Entity<Rental>().HasData(initialRentals);
        }
    }
}
