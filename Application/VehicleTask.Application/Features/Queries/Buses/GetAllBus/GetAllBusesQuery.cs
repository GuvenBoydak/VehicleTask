using MediatR;
using VehicleTask.Application.DTOs.Buses;
using VehicleTask.Application.DTOs.Cars;

namespace VehicleTask.Application.Features.Queries.Buses.GetAllBus;

public class GetAllBusesQuery : IRequest<List<BusListDto>>
{
}