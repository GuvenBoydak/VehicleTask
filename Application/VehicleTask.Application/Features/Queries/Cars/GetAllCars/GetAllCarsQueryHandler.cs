using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Cars;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Queries.Cars.GetAllCars;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, List<CarListDto>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetAllCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<List<CarListDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAllAsync();

        return _mapper.Map<List<Car>, List<CarListDto>>(cars);
    }
}