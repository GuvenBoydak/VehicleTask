using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Infrastructure.EntityConfigurations;

public class CarConfiguration:IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Brand).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Wheel).IsRequired();
        builder.Property(x => x.SeatCapacity).IsRequired();
        
        builder.HasOne(x => x.Color)
            .WithMany(x => x.Cars)
            .HasForeignKey(x => x.ColorId);
    }
}