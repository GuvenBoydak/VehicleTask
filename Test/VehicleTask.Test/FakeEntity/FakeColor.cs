using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Test.FakeEntity;

public static class FakeColor
{
    public static readonly Color WhiteColor;
    public static readonly Color BlackColor;

    static FakeColor()
    {
        WhiteColor = new Color()
        {
            Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name = "Beyaz"
        };
        BlackColor = new Color()
        {
            Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name = "Siyah"
        };
    }
}