using MediatR;
using VehicleTask.Application.DTOs.Buses;

namespace VehicleTask.Application.Features.Command.Buses.UpdateBus;

public class UpdateBusCommand : IRequest<BusDto>
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public int SeatCapacity { get; set; }
    public bool IsHeadlightOn { get; set; }
    public int Wheel { get; set; }
    public Guid ColorId { get; set; }
}