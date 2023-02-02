using MediatR;

namespace VehicleTask.Application.Features.Command.Color.UpdateColor;

public class UpdateColorCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}