using MediatR;
using VehicleTask.Application.DTOs.Buses;

namespace VehicleTask.Application.Features.Command.Buses.CreateBus;

public class CreateBusCommand : IRequest<BusDto>
{
    public string Brand { get; set; }
    public int SeatCapacity { get; set; }
    public bool IsHeadlightOn { get; set; }
    public int Wheel { get; set; }
    public Guid ColorId { get; set; }
}