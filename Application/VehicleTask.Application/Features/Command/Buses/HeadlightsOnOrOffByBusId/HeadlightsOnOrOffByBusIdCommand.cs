using MediatR;
using VehicleTask.Application.DTOs.Buses;

namespace VehicleTask.Application.Features.Command.Buses.HeadlightsOnOrOffByBusId;

public class HeadlightsOnOrOffByBusIdCommand:IRequest<BusDto>
{
    public Guid Id { get; set; }
    public bool IsHeadlightOn { get; set; }
}