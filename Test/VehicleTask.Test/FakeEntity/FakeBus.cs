using VehicleTask.Domain.Models.Concrete;
using VehicleTask.Test.TestSetup;

namespace VehicleTask.Test.FakeEntity;

public static class FakeBus
{
    public static readonly Bus ScalaBus;
    public static readonly Bus FordBus;

    static FakeBus()
    {
        ScalaBus = new Bus()
        {
            Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Brand = "Scala", Wheel = 8, SeatCapacity = 6,
            IsHeadlightOn = false, ColorId = FakeColor.WhiteColor.Id
        };
        FordBus = new Bus()
        {
            Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Brand = "Ford", Wheel = 6, SeatCapacity = 3,
            IsHeadlightOn = false, ColorId = FakeColor.BlackColor.Id
        };
    }
}