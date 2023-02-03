using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Boats;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Boats.CreateBoat;

public class CreateBoatCommandHandler : IRequestHandler<CreateBoatCommand, BoatDto>
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

    public async Task<BoatDto> Handle(CreateBoatCommand request, CancellationToken cancellationToken)
    {
        var boat = _mapper.Map<CreateBoatCommand, Domain.Models.Concrete.Boat>(request);

        await _boatRepository.AddAsync(boat);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<Domain.Models.Concrete.Boat, BoatDto>(boat);
    }
}