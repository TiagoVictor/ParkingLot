using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity = Domain.Car.Entitie;

namespace Data.Car.Mapping;
public class CarMap : IEntityTypeConfiguration<Entity.Car>
{
    public void Configure(EntityTypeBuilder<Entity.Car> builder)
    {
        builder
            .ToTable("Cars");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Plate)
            .IsRequired()
            .HasColumnName("Plate")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(12);

        builder
            .Property(x => x.Model)
            .IsRequired()
            .HasColumnName("Model")
            .HasColumnType("NVARCAR")
            .HasMaxLength(255);

        builder
            .Property(x => x.Manufacturer)
            .IsRequired()
            .HasColumnName("Manufacturer")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder
            .HasIndex(x => x.Id, "IDX_CAR_ID");

        builder
            .HasIndex(x => x.Plate, "IDX_CAR_PLATE");


    }
}
