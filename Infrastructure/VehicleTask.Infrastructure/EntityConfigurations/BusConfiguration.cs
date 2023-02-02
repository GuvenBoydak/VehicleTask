using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Infrastructure.EntityConfigurations;

public class BusConfiguration:IEntityTypeConfiguration<Bus>
{
    public void Configure(EntityTypeBuilder<Bus> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Brand).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Wheel).IsRequired();
        builder.Property(x => x.SeatCapacity).IsRequired();
        
        builder.HasOne(x => x.Color)
            .WithMany(x => x.Buses)
            .HasForeignKey(x => x.ColorId);
    }
}