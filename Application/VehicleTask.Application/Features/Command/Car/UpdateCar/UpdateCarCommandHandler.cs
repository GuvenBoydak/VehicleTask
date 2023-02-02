using AutoMapper;
using MediatR;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Car.UpdateCar;

public class UpdateCarCommandHandler : AsyncRequestHandler<UpdateCarCommand>
{
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCarCommandHandler(IMapper mapper, ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = _mapper.Map<UpdateCarCommand, Domain.Models.Concrete.Car>(request);

        _carRepository.Update(car);
        await _unitOfWork.SaveChangesAsync();
    }
}