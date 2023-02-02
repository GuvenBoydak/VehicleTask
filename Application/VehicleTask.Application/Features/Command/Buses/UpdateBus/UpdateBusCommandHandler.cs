using AutoMapper;
using MediatR;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Buses.UpdateBus;

public class UpdateBusCommandHandler : AsyncRequestHandler<UpdateBusCommand>
{
    private readonly IMapper _mapper;
    private readonly IBusRepository _busRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBusCommandHandler(IMapper mapper, IBusRepository busRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _busRepository = busRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(UpdateBusCommand request, CancellationToken cancellationToken)
    {
        var bus = _mapper.Map<UpdateBusCommand, Domain.Models.Concrete.Bus>(request);

        _busRepository.Update(bus);
        await _unitOfWork.SaveChangesAsync();
    }
}