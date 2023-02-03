using MediatR;
using VehicleTask.Application.DTOs.Colors;

namespace VehicleTask.Application.Features.Command.Color.UpdateColor;

public class UpdateColorCommand : IRequest<ColorDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}