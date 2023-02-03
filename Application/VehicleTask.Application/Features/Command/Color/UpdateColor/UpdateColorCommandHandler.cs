using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Colors;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;

namespace VehicleTask.Application.Features.Command.Color.UpdateColor;

public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, ColorDto>
{
    private readonly IColorRepository _colorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateColorCommandHandler(IColorRepository colorRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _colorRepository = colorRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ColorDto> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
    {
        var color = _mapper.Map<UpdateColorCommand, Domain.Models.Concrete.Color>(request);

        _colorRepository.Update(color);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<Domain.Models.Concrete.Color, ColorDto>(color);
    }
}