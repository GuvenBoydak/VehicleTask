using MediatR;
using VehicleTask.Application.DTOs.Cars;

namespace VehicleTask.Application.Features.Command.Car.UpdateCar;

public class UpdateCarCommand : IRequest<CarDto>
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public int SeatCapacity { get; set; }
    public bool IsHeadlightOn { get; set; }
    public int Wheel { get; set; }
    public Guid ColorId { get; set; }
}