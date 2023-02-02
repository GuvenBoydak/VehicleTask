using MediatR;

namespace VehicleTask.Application.Features.Command.Buses.CreateBus;

public class CreateBusCommand : IRequest
{
    public string Brand { get; set; }
    public int SeatCapacity { get; set; }
    public bool IsHeadlightOn { get; set; }
    public int Wheel { get; set; }
    public Guid ColorId { get; set; }
}