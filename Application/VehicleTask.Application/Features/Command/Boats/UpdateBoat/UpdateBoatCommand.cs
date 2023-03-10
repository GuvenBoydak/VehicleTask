using MediatR;
using VehicleTask.Application.DTOs.Boats;

namespace VehicleTask.Application.Features.Command.Boats.UpdateBoat;

public class UpdateBoatCommand : IRequest<BoatDto>
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public int SeatCapacity { get; set; }
    public bool IsHeadlightOn { get; set; }
    public Guid ColorId { get; set; }
}