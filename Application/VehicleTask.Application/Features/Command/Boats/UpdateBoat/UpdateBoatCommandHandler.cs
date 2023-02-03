using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Boats;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Command.Boats.UpdateBoat;

public class UpdateBoatCommandHandler : IRequestHandler<UpdateBoatCommand, BoatDto>
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

    public async Task<BoatDto> Handle(UpdateBoatCommand request, CancellationToken cancellationToken)
    {
        var boat = _mapper.Map<UpdateBoatCommand, Domain.Models.Concrete.Boat>(request);

        _boatRepository.Update(boat);
        await _unitOfWork.SaveChangesAsync();

        var currentBoat=await _boatRepository.GetById(boat.Id);
        return _mapper.Map<Boat, BoatDto>(currentBoat);
    }
}