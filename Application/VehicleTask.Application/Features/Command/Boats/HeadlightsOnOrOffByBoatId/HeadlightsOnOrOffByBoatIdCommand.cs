using MediatR;
using VehicleTask.Application.DTOs.Boats;

namespace VehicleTask.Application.Features.Command.Boats.HeadlightsOnOrOffByBoatId;

public class HeadlightsOnOrOffByBoatIdCommand : IRequest<BoatDto>
{
    public Guid Id { get; set; }
    public bool IsHeadlightOn { get; set; }
}