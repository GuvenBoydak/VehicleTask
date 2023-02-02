using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleTask.Application.DTOs.Boats;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Queries.Boats.GetBoatsByColorId;

public class GetBoatsByColorIdQueryHandler : IRequestHandler<GetBoatsByColorIdQuery, List<BoatListDto>>
{
    private readonly IBoatRepository _boatRepository;
    private readonly IMapper _mapper;

    public GetBoatsByColorIdQueryHandler(IMapper mapper, IBoatRepository boatRepository)
    {
        _mapper = mapper;
        _boatRepository = boatRepository;
    }

    public async Task<List<BoatListDto>> Handle(GetBoatsByColorIdQuery request, CancellationToken cancellationToken)
    {
        var boats = await _boatRepository.Where(x => x.ColorId == request.ColorId).ToListAsync();

        return _mapper.Map<List<Boat>, List<BoatListDto>>(boats);
    }
}