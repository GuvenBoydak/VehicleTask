using MediatR;

namespace VehicleTask.Application.Features.Command.Car.HeadlightsOnOrOffByCarId;

public class HeadlightsOnOrOffByCarIdCommand:IRequest
{
    public Guid Id { get; set; }
    public bool IsHeadlightOn { get; set; }
}