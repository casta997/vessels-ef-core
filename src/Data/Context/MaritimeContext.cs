using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

public class MaritimeContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }

    internal DbSet<Vessel> Vessels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer($"Server=(localdb)\\quellochevuoi;Database=envDev;Trusted_Connection=True");
}
