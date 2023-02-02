using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Infrastructure.EntityConfigurations;

public class BoatConfiguration:IEntityTypeConfiguration<Boat>
{
    public void Configure(EntityTypeBuilder<Boat> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Brand).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Color).IsRequired().HasMaxLength(50);
        builder.Property(x => x.SeatCapacity).IsRequired();
    }
}