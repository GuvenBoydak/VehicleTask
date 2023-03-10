using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleTask.Application.DTOs.Buses;
using VehicleTask.Application.DTOs.Responce;
using VehicleTask.Application.Features.Command.Buses.CreateBus;
using VehicleTask.Application.Features.Command.Buses.DeleteBus;
using VehicleTask.Application.Features.Command.Buses.HeadlightsOnOrOffByBusId;
using VehicleTask.Application.Features.Command.Buses.UpdateBus;
using VehicleTask.Application.Features.Queries.Buses.GetAllBus;
using VehicleTask.Application.Features.Queries.Buses.GetBusesByColorId;

namespace VehicleTask.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BusesController : BaseController
{
    private readonly IMediator _mediator;

    public BusesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllBusesQuery request)
    {
        var busList = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<List<BusListDto>>.Success(200, busList));
    }

    [HttpGet]
    [Route("{ColorId:guid}")]
    public async Task<IActionResult> GetBusesByColorId([FromRoute] GetBusesByColorIdQuery request)
    {
        var busList = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<List<BusListDto>>.Success(200, busList));
    }

    [HttpPost]
    [Route("Headlights-On-Or-Off-ByBusId")]
    public async Task<IActionResult> Add([FromBody] HeadlightsOnOrOffByBusIdCommand request)
    {
        var responce = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<BusDto>.Success(200, responce));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBusCommand request)
    {
        var responce = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<BusDto>.Success(200, responce));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBusCommand request)
    {
        var responce = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<BusDto>.Success(200, responce));
    }

    [HttpDelete]
    [Route("{Id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteBusCommand request)
    {
        await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
}