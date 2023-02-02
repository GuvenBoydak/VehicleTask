using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleTask.Application.DTOs.Cars;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Queries.Cars.GetCarsByColorId;

public class GetCarsByColorIdQueryHandler : IRequestHandler<GetCarsByColorIdQuery, List<CarListDto>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetCarsByColorIdQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<List<CarListDto>> Handle(GetCarsByColorIdQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.Where(x => x.ColorId == request.ColorId).ToListAsync();

        return _mapper.Map<List<Car>, List<CarListDto>>(cars);
    }
}