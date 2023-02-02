using AutoMapper;
using MediatR;
using VehicleTask.Application.Features.Command.Car.CreateCar;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Buses.CreateBus;

public class CreateBusCommandHandler : AsyncRequestHandler<CreateBusCommand>
{
    private readonly IMapper _mapper;
    private readonly IBusRepository _busRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBusCommandHandler(IMapper mapper, IBusRepository busRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _busRepository = busRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(CreateBusCommand request, CancellationToken cancellationToken)
    {
        var bus = _mapper.Map<CreateBusCommand, Domain.Models.Concrete.Bus>(request);

        await _busRepository.AddAsync(bus);
        await _unitOfWork.SaveChangesAsync();
    }
}