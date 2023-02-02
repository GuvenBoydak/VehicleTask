using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Colors;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Queries.Colors.GetByIdColor;

public class GetColorByIdQueryHandler : IRequestHandler<GetColorByIdQuery, ColorDto>
{
    private readonly IColorRepository _colorRepository;
    private readonly IMapper _mapper;

    public GetColorByIdQueryHandler(IColorRepository colorRepository, IMapper mapper)
    {
        _colorRepository = colorRepository;
        _mapper = mapper;
    }

    public async Task<ColorDto> Handle(GetColorByIdQuery request, CancellationToken cancellationToken)
    {
        var color = await _colorRepository.GetById(request.Id);

        return _mapper.Map<Color, ColorDto>(color);
    }
}