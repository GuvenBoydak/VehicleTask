using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Boats;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Command.Boats.HeadlightsOnOrOffByBoatId;

public class HeadlightsOnOrOffByBoatIdCommandHandler : IRequestHandler<HeadlightsOnOrOffByBoatIdCommand, BoatDto>
{
    private readonly IMapper _mapper;
    private readonly IBoatRepository _boatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HeadlightsOnOrOffByBoatIdCommandHandler(IMapper mapper, IBoatRepository boatRepository,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _boatRepository = boatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<BoatDto> Handle(HeadlightsOnOrOffByBoatIdCommand request, CancellationToken cancellationToken)
    {
        var boat = new Boat() { Id = request.Id, IsHeadlightOn = request.IsHeadlightOn };

        _boatRepository.Update(boat);
        await _unitOfWork.SaveChangesAsync();

        var currentBoat=await _boatRepository.GetById(boat.Id);
        return _mapper.Map<Boat, BoatDto>(currentBoat);
    }
}