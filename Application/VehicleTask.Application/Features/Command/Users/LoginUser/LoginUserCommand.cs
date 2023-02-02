using MediatR;
using VehicleTask.Application.DTOs;

namespace VehicleTask.Application.Features.Command.Users.LoginUser;

public class LoginUserCommand : IRequest<Token>
{
    public string Email { get; set; }
    public string Password { get; set; }
}