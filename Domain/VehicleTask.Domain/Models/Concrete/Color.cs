using VehicleTask.Domain.Models.Abstract;

namespace VehicleTask.Domain.Models.Concrete;

public class Color:IBaseEntity
{
    public Color()
    {
        Id=Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
        IsDeleted = false;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
    
    //Relational Property
    public List<Bus> Buses { get; set; }
    public List<Car> Cars { get; set; }
    public List<Boat> Boats { get; set; }
}