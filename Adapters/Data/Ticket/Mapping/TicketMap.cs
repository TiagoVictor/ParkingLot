using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity = Domain.Ticket.Entitie;

namespace Data.Ticket.Mapping;
public class TicketMap : IEntityTypeConfiguration<Entity.Ticket>
{
    public void Configure(EntityTypeBuilder<Entity.Ticket> builder)
    {
        builder
            .ToTable("Tickets");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Start)
            .IsRequired()
            .HasColumnName("Start")
            .HasColumnType("DATETIME")
            .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder
            .Property(x => x.End)
            .IsRequired()
            .HasColumnName("End")
            .HasColumnType("DATETIME")
            .HasDefaultValue(DateTime.MinValue.ToUniversalTime());

        builder
            .HasOne(x => x.Car)
            .WithMany(x => x.Tickets)
            .HasForeignKey("CarId")
            .HasConstraintName("FK_TICKETS_CAR")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasIndex(x => x.Id, "IDX_TICKET_ID");
        
    }
}
