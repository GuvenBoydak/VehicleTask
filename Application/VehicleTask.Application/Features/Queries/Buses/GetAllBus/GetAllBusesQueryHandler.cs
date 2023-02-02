using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Buses;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Queries.Buses.GetAllBus;

public class GetAllBusesQueryHandler : IRequestHandler<GetAllBusesQuery, List<BusListDto>>
{
    private readonly IBusRepository _busRepository;
    private readonly IMapper _mapper;

    public GetAllBusesQueryHandler(IBusRepository busRepository, IMapper mapper)
    {
        _busRepository = busRepository;
        _mapper = mapper;
    }

    public async Task<List<BusListDto>> Handle(GetAllBusesQuery request, CancellationToken cancellationToken)
    {
        var buses = await _busRepository.GetAllAsync();

        return _mapper.Map<List<Bus>, List<BusListDto>>(buses);
    }
}