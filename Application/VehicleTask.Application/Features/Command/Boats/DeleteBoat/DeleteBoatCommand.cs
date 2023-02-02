using MediatR;

namespace VehicleTask.Application.Features.Command.Boats.DeleteBoat;

public class DeleteBoatCommand : IRequest
{
    public Guid Id { get; set; }
}