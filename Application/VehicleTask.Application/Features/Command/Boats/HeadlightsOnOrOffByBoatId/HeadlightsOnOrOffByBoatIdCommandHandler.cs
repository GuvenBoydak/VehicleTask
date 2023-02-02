﻿using AutoMapper;
using MediatR;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Boats.HeadlightsOnOrOffByBoatId;

public class HeadlightsOnOrOffByBoatIdCommandHandler : AsyncRequestHandler<HeadlightsOnOrOffByBoatIdCommand>
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

    protected override async Task Handle(HeadlightsOnOrOffByBoatIdCommand request, CancellationToken cancellationToken)
    {
        var boat = _mapper.Map<HeadlightsOnOrOffByBoatIdCommand, Domain.Models.Concrete.Boat>(request);

        _boatRepository.Update(boat);
        await _unitOfWork.SaveChangesAsync();
    }
}