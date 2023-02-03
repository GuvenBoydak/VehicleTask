using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleTask.Application.DTOs.Colors;
using VehicleTask.Application.DTOs.Responce;
using VehicleTask.Application.Features.Command.Color.CreateColor;
using VehicleTask.Application.Features.Command.Color.DeleteColor;
using VehicleTask.Application.Features.Command.Color.UpdateColor;
using VehicleTask.Application.Features.Queries.Colors.GetAllColors;
using VehicleTask.Application.Features.Queries.Colors.GetByIdColor;

namespace VehicleTask.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ColorsController : BaseController
{
    private readonly IMediator _mediator;

    public ColorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllColorsQuery request)
    {
        var colorList = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<List<ColorListDto>>.Success(200, colorList));
    }

    [HttpGet]
    [Route("{Id:guid}")]
    public async Task<IActionResult> GetColorById([FromRoute] GetColorByIdQuery request)
    {
        var color = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<ColorDto>.Success(200, color));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateColorCommand request)
    {
        var responce = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<ColorDto>.Success(200, responce));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateColorCommand request)
    {
        var responce = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<ColorDto>.Success(200, responce));
    }

    [HttpDelete]
    [Route("{Id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteColorCommand request)
    {
        await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
}