using MediatR;

namespace VehicleTask.Application.Features.Command.Color.DeleteColor;

public class DeleteColorCommand : IRequest
{
    public Guid Id { get; set; }
}