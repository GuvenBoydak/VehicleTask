using MediatR;

namespace VehicleTask.Application.Features.Command.Boats.HeadlightsOnOrOffByBoatId;

public class HeadlightsOnOrOffByBoatIdCommand:IRequest
{
    public Guid Id { get; set; }
    public bool IsHeadlightOn { get; set; }
}