using VehicleTask.Domain.Models.Abstract;

namespace VehicleTask.Domain.Models.Concrete;

public class Boat:Vehicle
{
    public Guid ColorId { get; set; }
    
    //Relational Property
    public Color Color { get; set; }
}