using MediatR;

namespace VehicleTask.Application.Features.Command.Boats.CreateBoat;

public class CreateBoatCommand : IRequest
{
    public string Brand { get; set; }
    public int SeatCapacity { get; set; }
    public bool IsHeadlightOn { get; set; }
    public Guid ColorId { get; set; }
}