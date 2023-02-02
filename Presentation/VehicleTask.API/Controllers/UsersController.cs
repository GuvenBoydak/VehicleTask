using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTask.Application.DTOs;
using VehicleTask.Application.DTOs.Responce;
using VehicleTask.Application.DTOs.Users;
using VehicleTask.Application.Features.Command.Users.LoginUser;
using VehicleTask.Application.Features.Command.Users.RegisterUser;
using VehicleTask.Application.Features.Queries.Users.GetAllUsers;

namespace VehicleTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllUserQuery request)
    {
        var users = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<List<UserListDto>>.Success(200, users));
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand request)
    {
        await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand request)
    {
        var token = await _mediator.Send(request);
        return CreateActionResult(CustomResponseDto<Token>.Success(200, token));
    }
}