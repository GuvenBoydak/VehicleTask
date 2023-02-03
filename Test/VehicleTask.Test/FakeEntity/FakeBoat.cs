using VehicleTask.Domain.Models.Concrete;
using VehicleTask.Test.TestSetup;

namespace VehicleTask.Test.FakeEntity;

public static class FakeBoat
{
    public static readonly Boat BeneteauBoat;
    public static readonly Boat JeanneauBoat;

    static FakeBoat()
    {
        BeneteauBoat = new Boat()
        {
            Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Brand = "Beneteau", SeatCapacity = 6,
            IsHeadlightOn = false, ColorId = FakeColor.WhiteColor.Id
        };
        JeanneauBoat = new Boat()
        {
            Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Brand = "Jeanneau", SeatCapacity = 6,
            IsHeadlightOn = false, ColorId = FakeColor.BlackColor.Id
        };
    }
}