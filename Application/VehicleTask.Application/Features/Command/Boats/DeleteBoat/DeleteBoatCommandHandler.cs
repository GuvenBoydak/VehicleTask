using MediatR;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Boats.DeleteBoat;

public class DeleteBoatCommandHandler : AsyncRequestHandler<DeleteBoatCommand>
{
    private readonly IBoatRepository _boatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBoatCommandHandler(IBoatRepository boatRepository, IUnitOfWork unitOfWork)
    {
        _boatRepository = boatRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(DeleteBoatCommand request, CancellationToken cancellationToken)
    {
        await _boatRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}