namespace VehicleTask.Domain.Models.Abstract;

public abstract class Vehicle
{
    protected Vehicle()
    {
        CreatedDate = DateTime.UtcNow;
        IsDeleted = false;
    }

    public Guid Id { get; set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public int SeatCapacity { get; set; }
    public bool IsHeadlightOn { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}