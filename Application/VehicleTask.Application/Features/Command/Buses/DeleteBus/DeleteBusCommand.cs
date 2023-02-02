using MediatR;

namespace VehicleTask.Application.Features.Command.Buses.DeleteBus;

public class DeleteBusCommand : IRequest
{
    public Guid Id { get; set; }
}