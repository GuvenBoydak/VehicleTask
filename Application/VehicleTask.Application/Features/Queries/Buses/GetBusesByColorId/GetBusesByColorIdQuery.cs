using MediatR;
using VehicleTask.Application.DTOs.Buses;

namespace VehicleTask.Application.Features.Queries.Buses.GetBusesByColorId;

public class GetBusesByColorIdQuery : IRequest<List<BusListDto>>
{
    public Guid ColorId { get; set; }
}