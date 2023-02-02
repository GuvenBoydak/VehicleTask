using MediatR;
using VehicleTask.Application.DTOs.Colors;

namespace VehicleTask.Application.Features.Queries.Colors.GetAllColors;

public class GetAllColorsQuery : IRequest<List<ColorListDto>>
{
}