using MediatR;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Buses.DeleteBus;

public class DeleteBusCommandHandler : AsyncRequestHandler<DeleteBusCommand>
{
    private readonly IBusRepository _busRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBusCommandHandler( IBusRepository busRepository, IUnitOfWork unitOfWork)
    {
        _busRepository = busRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(DeleteBusCommand request, CancellationToken cancellationToken)
    {
        await _busRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}