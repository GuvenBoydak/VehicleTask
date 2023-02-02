using AutoMapper;
using MediatR;
using VehicleTask.Application.Features.Command.Buses.CreateBus;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Boats.CreateBoat;

public class CreateBoatCommandHandler : AsyncRequestHandler<CreateBoatCommand>
{
    private readonly IMapper _mapper;
    private readonly IBoatRepository _boatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBoatCommandHandler(IMapper mapper, IBoatRepository boatRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _boatRepository = boatRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(CreateBoatCommand request, CancellationToken cancellationToken)
    {
        var boat = _mapper.Map<CreateBoatCommand, Domain.Models.Concrete.Boat>(request);

        await _boatRepository.AddAsync(boat);
        await _unitOfWork.SaveChangesAsync();
    }
}