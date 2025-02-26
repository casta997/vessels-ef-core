using Microsoft.EntityFrameworkCore;
using VesselManagementData.Models;

namespace VesselManagementData
{
    public class VesselManagemetContext : DbContext
    {
        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server = (localdb)\test; Database = VesselManagement; Trusted_Connection = True; ConnectRetryCount = 0"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var initialVessels = new[]
            {
                new Vessel {Id = 1, ImoNumber = "IMO 0000001"},
                new Vessel {Id = 2, ImoNumber = "IMO 0000002"}
            };
            modelBuilder.Entity<Vessel>().HasData(initialVessels);

            var initialOwners = new[]
            {
                new Owner {Id = 1, FirstName = "Giorgio", LastName = "Tomaino"},
                new Owner {Id = 2, FirstName = "Tommaso", LastName = "Turigliato"}
            };
            modelBuilder.Entity<Owner>().HasData(initialOwners);
        }
    }
}
