using Microsoft.EntityFrameworkCore;
using VehicleTask.Domain.Models.Concrete;
using VehicleTask.Infrastructure.Context;
using VehicleTask.Test.FakeEntity;

namespace VehicleTask.Test.TestSetup;

public class VehicleTestContext : VehicleDbContext
{
    public VehicleTestContext(DbContextOptions<VehicleDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>().HasData(
            FakeColor.WhiteColor,
            FakeColor.BlackColor
        );
        modelBuilder.Entity<Car>().HasData(
            FakeCar.ToyotaCar,
            FakeCar.OpelCar
        );
        modelBuilder.Entity<Boat>().HasData(
            FakeBoat.BeneteauBoat,
            FakeBoat.JeanneauBoat
        );
        modelBuilder.Entity<Bus>().HasData(
            FakeBus.ScalaBus,
            FakeBus.FordBus
        );
        modelBuilder.Entity<User>().HasData(
            FakeUser.Test
        );
    }
}