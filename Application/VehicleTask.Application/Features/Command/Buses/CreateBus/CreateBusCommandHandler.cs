using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Buses;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Buses.CreateBus;

public class CreateBusCommandHandler : IRequestHandler<CreateBusCommand, BusDto>
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

    public async Task<BusDto> Handle(CreateBusCommand request, CancellationToken cancellationToken)
    {
        var bus = _mapper.Map<CreateBusCommand, Domain.Models.Concrete.Bus>(request);

        await _busRepository.AddAsync(bus);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<Domain.Models.Concrete.Bus, BusDto>(bus);
    }
}