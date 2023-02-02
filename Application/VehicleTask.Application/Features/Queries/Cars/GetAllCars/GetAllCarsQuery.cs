using MediatR;
using VehicleTask.Application.DTOs.Cars;

namespace VehicleTask.Application.Features.Queries.Cars.GetAllCars;

public class GetAllCarsQuery : IRequest<List<CarListDto>>
{
}