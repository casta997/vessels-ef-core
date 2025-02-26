using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

public class MaritimeContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }

    internal DbSet<Vessel> Vessels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer($"Server=(localdb)\\CCC;Database=test_con_William;Trusted_Connection=True");
}
