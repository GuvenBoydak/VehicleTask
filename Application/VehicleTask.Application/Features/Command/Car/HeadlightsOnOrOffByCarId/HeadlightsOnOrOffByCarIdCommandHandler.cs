using AutoMapper;
using MediatR;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Car.HeadlightsOnOrOffByCarId;

public class HeadlightsOnOrOffByCarIdCommandHandler : AsyncRequestHandler<HeadlightsOnOrOffByCarIdCommand>
{
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HeadlightsOnOrOffByCarIdCommandHandler(IMapper mapper, ICarRepository carRepository,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(HeadlightsOnOrOffByCarIdCommand request, CancellationToken cancellationToken)
    {
        var car = _mapper.Map<HeadlightsOnOrOffByCarIdCommand, Domain.Models.Concrete.Car>(request);

        _carRepository.Update(car);
        await _unitOfWork.SaveChangesAsync();
    }
}