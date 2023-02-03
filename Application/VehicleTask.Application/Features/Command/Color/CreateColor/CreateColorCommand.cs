using MediatR;
using VehicleTask.Application.DTOs.Colors;

namespace VehicleTask.Application.Features.Command.Color.CreateColor;

public class CreateColorCommand : IRequest<ColorDto>
{
    public string Name { get; set; }
}