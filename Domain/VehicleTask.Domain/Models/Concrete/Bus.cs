using VehicleTask.Domain.Models.Abstract;

namespace VehicleTask.Domain.Models.Concrete;

public class Bus:Vehicle
{
    public int Wheel { get; set; }
    public Guid ColorId { get; set; }
    
    //Relational Property
    public Color Color { get; set; }
}