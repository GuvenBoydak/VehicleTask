using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleTask.Application.DTOs.Boats;
using VehicleTask.Application.DTOs.Responce;
using VehicleTask.Application.Features.Command.Boats.CreateBoat;
using VehicleTask.Application.Features.Command.Boats.DeleteBoat;
using VehicleTask.Application.Features.Command.Boats.HeadlightsOnOrOffByBoatId;
using VehicleTask.Application.Features.Command.Boats.UpdateBoat;
using VehicleTask.Application.Features.Queries.Boats.GetAllBoats;
using VehicleTask.Application.Features.Queries.Boats.GetBoatsByColorId;

namespace VehicleTask.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BoatsController : BaseController
{
    private readonly IMediator _mediator;

    public BoatsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllBoatsQuery request)
    {
        var boatList = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<List<BoatListDto>>.Success(200, boatList));
    }

    [HttpGet]
    [Route("{ColorId:guid}")]
    public async Task<IActionResult> GetBoatsByColorId([FromRoute] GetBoatsByColorIdQuery request)
    {
        var boatList = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<List<BoatListDto>>.Success(200, boatList));
    }

    [HttpPost]
    [Route("Headlights-On-Or-Off-ByBoatId")]
    public async Task<IActionResult> Add([FromBody] HeadlightsOnOrOffByBoatIdCommand request)
    {
        var responce = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<BoatDto>.Success(200, responce));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBoatCommand request)
    {
        var responce = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<BoatDto>.Success(200, responce));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBoatCommand request)
    {
        var responce = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<BoatDto>.Success(200, responce));
    }

    [HttpDelete]
    [Route("{Id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteBoatCommand request)
    {
        await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
}