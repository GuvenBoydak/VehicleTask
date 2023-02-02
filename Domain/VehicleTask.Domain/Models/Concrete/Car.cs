using VehicleTask.Domain.Models.Abstract;

namespace VehicleTask.Domain.Models.Concrete;

public class Car:Vehicle
{
    public int Wheel { get; set; }
}