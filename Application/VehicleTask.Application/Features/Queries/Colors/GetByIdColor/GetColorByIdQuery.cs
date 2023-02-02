using MediatR;
using VehicleTask.Application.DTOs.Colors;

namespace VehicleTask.Application.Features.Queries.Colors.GetByIdColor;

public class GetColorByIdQuery : IRequest<ColorDto>
{
    public Guid Id { get; set; }
}