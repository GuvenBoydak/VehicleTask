using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Cars;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Car.CreateCar;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CarDto>
{
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = _mapper.Map<CreateCarCommand, Domain.Models.Concrete.Car>(request);

        await _carRepository.AddAsync(car);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<Domain.Models.Concrete.Car, CarDto>(car);
    }
}