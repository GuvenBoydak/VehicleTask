using MediatR;
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
    public async Task<IActionResult> Add([FromBody] HeadlightsOnOrOffByCarIdCommand request)
    {
        await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCarCommand request)
    {
        await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCarCommand request)
    {
        await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

    [HttpDelete]
    [Route("{Id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteCarCommand request)
    {
        await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
}