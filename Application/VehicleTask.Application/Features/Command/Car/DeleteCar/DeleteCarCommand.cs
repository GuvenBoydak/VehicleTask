using MediatR;

namespace VehicleTask.Application.Features.Command.Car.DeleteCar;

public class DeleteCarCommand : IRequest
{
    public Guid Id { get; set; }
}