using AutoMapper;
using MediatR;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Buses.HeadlightsOnOrOffByBusId;

public class HeadlightsOnOrOffByBusIdCommandHandler : AsyncRequestHandler<HeadlightsOnOrOffByBusIdCommand>
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

    protected override async Task Handle(HeadlightsOnOrOffByBusIdCommand request, CancellationToken cancellationToken)
    {
        var bus = _mapper.Map<HeadlightsOnOrOffByBusIdCommand, Domain.Models.Concrete.Bus>(request);

        _busRepository.Update(bus);
        await _unitOfWork.SaveChangesAsync();
    }
}