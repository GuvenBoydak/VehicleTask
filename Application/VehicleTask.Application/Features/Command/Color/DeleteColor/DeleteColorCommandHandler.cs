using MediatR;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Color.DeleteColor;

public class DeleteColorCommandHandler : AsyncRequestHandler<DeleteColorCommand>
{
    private readonly IColorRepository _colorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteColorCommandHandler(IColorRepository colorRepository, IUnitOfWork unitOfWork)
    {
        _colorRepository = colorRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(DeleteColorCommand request, CancellationToken cancellationToken)
    {
        await _colorRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}