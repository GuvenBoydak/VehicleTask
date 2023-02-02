using MediatR;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Car.DeleteCar;

public class DeleteCarCommandHandler : AsyncRequestHandler<DeleteCarCommand>
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCarCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        await _carRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}