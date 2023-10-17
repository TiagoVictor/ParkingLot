using Data.Car.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class ParkingLotDbContext : DbContext
{
    public ParkingLotDbContext(DbContextOptions<ParkingLotDbContext> options) : base(options) { }

    public DbSet<Domain.Car.Entitie.Car> Cars { get; set; }
    public DbSet<Domain.Ticket.Entitie.Ticket> Tickets { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarMap());
    }
}
