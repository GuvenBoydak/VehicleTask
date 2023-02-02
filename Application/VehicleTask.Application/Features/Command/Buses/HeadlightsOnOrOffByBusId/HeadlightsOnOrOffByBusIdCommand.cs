using MediatR;

namespace VehicleTask.Application.Features.Command.Buses.HeadlightsOnOrOffByBusId;

public class HeadlightsOnOrOffByBusIdCommand:IRequest
{
    public Guid Id { get; set; }
    public bool IsHeadlightOn { get; set; }
}