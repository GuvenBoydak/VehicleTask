using VehicleTask.Domain.Models.Concrete;
using VehicleTask.Test.TestSetup;

namespace VehicleTask.Test.FakeEntity;

public static class FakeCar
{
    public static readonly Car OpelCar;
    public static readonly Car ToyotaCar;

    static FakeCar()
    {
        OpelCar = new Car()
        {
            Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Brand = "Opel", Wheel = 4, SeatCapacity = 5,
            IsHeadlightOn = false, ColorId = FakeColor.WhiteColor.Id
        };
        ToyotaCar = new Car()
        {
            Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Brand = "Toyota", Wheel = 4, SeatCapacity = 5,
            IsHeadlightOn = false, ColorId = FakeColor.BlackColor.Id
        };
    }
}