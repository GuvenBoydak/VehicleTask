using MediatR;
using VehicleTask.Application.DTOs.Cars;

namespace VehicleTask.Application.Features.Queries.Cars.GetCarsByColorId;

public class GetCarsByColorIdQuery : IRequest<List<CarListDto>>
{
    public Guid ColorId { get; set; }
}