using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Colors;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Queries.Colors.GetAllColors;

public class GetAllColorsQueryHandler : IRequestHandler<GetAllColorsQuery, List<ColorListDto>>
{
    private readonly IColorRepository _colorRepository;
    private readonly IMapper _mapper;

    public GetAllColorsQueryHandler(IColorRepository colorRepository, IMapper mapper)
    {
        _colorRepository = colorRepository;
        _mapper = mapper;
    }

    public async Task<List<ColorListDto>> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
    {
        var colors = await _colorRepository.GetAllAsync();

        return _mapper.Map<List<Color>, List<ColorListDto>>(colors);
    }
}