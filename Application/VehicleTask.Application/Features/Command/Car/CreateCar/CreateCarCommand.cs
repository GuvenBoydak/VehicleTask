using MediatR;
using VehicleTask.Application.DTOs.Cars;

namespace VehicleTask.Application.Features.Command.Car.CreateCar;

public class CreateCarCommand : IRequest<CarDto>
{
    public string Brand { get; set; }
    public int SeatCapacity { get; set; }
    public bool IsHeadlightOn { get; set; }
    public int Wheel { get; set; }
    public Guid ColorId { get; set; }
}