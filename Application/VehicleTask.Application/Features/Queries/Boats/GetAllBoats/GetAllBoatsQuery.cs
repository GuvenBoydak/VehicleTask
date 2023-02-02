using MediatR;
using VehicleTask.Application.DTOs.Boats;

namespace VehicleTask.Application.Features.Queries.Boats.GetAllBoats;

public class GetAllBoatsQuery : IRequest<List<BoatListDto>>
{
}