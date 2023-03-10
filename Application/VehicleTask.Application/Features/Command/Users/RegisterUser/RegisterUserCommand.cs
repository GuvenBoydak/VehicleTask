using MediatR;

namespace VehicleTask.Application.Features.Command.Users.RegisterUser;

public class RegisterUserCommand : IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}