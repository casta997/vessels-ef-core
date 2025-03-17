
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Context
{
    public class CarRentalContext : DbContext
    {

        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        {
        }
    }
}
