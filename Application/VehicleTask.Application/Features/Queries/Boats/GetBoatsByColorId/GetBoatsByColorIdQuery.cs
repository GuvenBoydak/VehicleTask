using MediatR;
using VehicleTask.Application.DTOs.Boats;

namespace VehicleTask.Application.Features.Queries.Boats.GetBoatsByColorId;

public class GetBoatsByColorIdQuery : IRequest<List<BoatListDto>>
{
    public Guid ColorId { get; set; }
}