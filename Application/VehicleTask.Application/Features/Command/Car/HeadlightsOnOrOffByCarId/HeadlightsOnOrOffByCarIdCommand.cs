using MediatR;
using VehicleTask.Application.DTOs.Cars;

namespace VehicleTask.Application.Features.Command.Car.HeadlightsOnOrOffByCarId;

public class HeadlightsOnOrOffByCarIdCommand:IRequest<CarDto>
{
    public Guid Id { get; set; }
    public bool IsHeadlightOn { get; set; }
}