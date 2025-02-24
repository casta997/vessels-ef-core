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
    }
}
