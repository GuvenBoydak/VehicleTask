using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleTask.Application.DTOs.Cars;
using VehicleTask.Application.DTOs.Responce;
using VehicleTask.Application.Features.Command.Car.CreateCar;
using VehicleTask.Application.Features.Command.Car.DeleteCar;
using VehicleTask.Application.Features.Command.Car.HeadlightsOnOrOffByCarId;
using VehicleTask.Application.Features.Command.Car.UpdateCar;
using VehicleTask.Application.Features.Queries.Cars.GetAllCars;
using VehicleTask.Application.Features.Queries.Cars.GetCarsByColorId;

namespace VehicleTask.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CarsController : BaseController
{
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCarsQuery request)
    {
        var carList = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<List<CarListDto>>.Success(200, carList));
    }

    [HttpGet]
    [Route("{ColorId:guid}")]
    public async Task<IActionResult> GetCarsByColorId([FromRoute] GetCarsByColorIdQuery request)
    {
        var carList = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<List<CarListDto>>.Success(200, carList));
    }

    [HttpPost]
    [Route("Headlights-On-Or-Off-ByCarId")]
    public async Task<IActionResult> HeadlightsOnOrOffByCarId([FromBody] HeadlightsOnOrOffByCarIdCommand request)
    {
        var responce = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<CarDto>.Success(200, responce));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCarCommand request)
    {
        var responce = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<CarDto>.Success(200, responce));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCarCommand request)
    {
        var responce = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<CarDto>.Success(200, responce));
    }

    [HttpDelete]
    [Route("{Id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteCarCommand request)
    {
        await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
}