using AutoMapper;
using MediatR;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Boats.UpdateBoat;

public class UpdateBoatCommandHandler : AsyncRequestHandler<UpdateBoatCommand>
{
    private readonly IMapper _mapper;
    private readonly IBoatRepository _boatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBoatCommandHandler(IMapper mapper, IBoatRepository boatRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _boatRepository = boatRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(UpdateBoatCommand request, CancellationToken cancellationToken)
    {
        var boat = _mapper.Map<UpdateBoatCommand, Domain.Models.Concrete.Boat>(request);

        _boatRepository.Update(boat);
        await _unitOfWork.SaveChangesAsync();
    }
}