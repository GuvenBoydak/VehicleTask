using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleTask.Application.DTOs.Buses;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Queries.Buses.GetBusesByColorId;

public class GetBusesByColorIdQueryHandler : IRequestHandler<GetBusesByColorIdQuery, List<BusListDto>>
{
    private readonly IBusRepository _busRepository;
    private readonly IMapper _mapper;

    public GetBusesByColorIdQueryHandler(IBusRepository busRepository, IMapper mapper)
    {
        _busRepository = busRepository;
        _mapper = mapper;
    }

    public async Task<List<BusListDto>> Handle(GetBusesByColorIdQuery request, CancellationToken cancellationToken)
    {
        var buses = await _busRepository.Where(x => x.ColorId == request.ColorId).ToListAsync();

        return _mapper.Map<List<Bus>, List<BusListDto>>(buses);
    }
}