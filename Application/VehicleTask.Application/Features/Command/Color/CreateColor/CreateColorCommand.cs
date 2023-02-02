using MediatR;

namespace VehicleTask.Application.Features.Command.Color.CreateColor;

public class CreateColorCommand : IRequest
{
    public string Name { get; set; }
}