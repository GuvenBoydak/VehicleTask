namespace VehicleTask.Application.DTOs.Boats;

public class BoatListDto
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public int SeatCapacity { get; set; }
    public bool IsHeadlightOn { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
    public Guid ColorId { get; set; }
}