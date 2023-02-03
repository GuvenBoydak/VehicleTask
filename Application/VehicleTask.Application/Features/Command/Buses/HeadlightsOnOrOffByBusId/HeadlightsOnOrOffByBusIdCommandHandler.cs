using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Buses;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Command.Buses.HeadlightsOnOrOffByBusId;

public class HeadlightsOnOrOffByBusIdCommandHandler : IRequestHandler<HeadlightsOnOrOffByBusIdCommand, BusDto>
{
    private readonly IMapper _mapper;
    private readonly IBusRepository _busRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HeadlightsOnOrOffByBusIdCommandHandler(IMapper mapper, IBusRepository busRepository,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _busRepository = busRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<BusDto> Handle(HeadlightsOnOrOffByBusIdCommand request, CancellationToken cancellationToken)
    {
        var bus = _mapper.Map<HeadlightsOnOrOffByBusIdCommand, Domain.Models.Concrete.Bus>(request);

        _busRepository.Update(bus);
        await _unitOfWork.SaveChangesAsync();

        var currentBus = await _busRepository.GetById(bus.Id);
        return _mapper.Map<Bus, BusDto>(currentBus);
    }
}