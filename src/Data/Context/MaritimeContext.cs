using Microsoft.EntityFrameworkCore;

namespace Data.Entities;
public class MaritimeContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Vessel> Vessels { get; set; }

    public MaritimeContext(DbContextOptions<MaritimeContext> options) : base(options) {
            this.Database.EnsureCreated();
    }

}
