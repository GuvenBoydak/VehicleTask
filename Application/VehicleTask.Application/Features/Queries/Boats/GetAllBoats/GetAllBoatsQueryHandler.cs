using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Boats;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Queries.Boats.GetAllBoats;

public class GetAllBoatsQueryHandler : IRequestHandler<GetAllBoatsQuery, List<BoatListDto>>
{
    private readonly IBoatRepository _boatRepository;
    private readonly IMapper _mapper;

    public GetAllBoatsQueryHandler(IBoatRepository boatRepository, IMapper mapper)
    {
        _boatRepository = boatRepository;
        _mapper = mapper;
    }

    public async Task<List<BoatListDto>> Handle(GetAllBoatsQuery request, CancellationToken cancellationToken)
    {
        var boats = await _boatRepository.GetAllAsync();

        return _mapper.Map<List<Boat>, List<BoatListDto>>(boats);
    }
}