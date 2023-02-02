namespace VehicleTask.Domain.Models.Abstract;

public abstract class Vehicle:IBaseEntity
{
    protected Vehicle()
    {
        Id=Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
        IsDeleted = false;
    }

    public Guid Id { get; set; }
    public string Brand { get; set; }
    public int SeatCapacity { get; set; }
    public bool IsHeadlightOn { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}