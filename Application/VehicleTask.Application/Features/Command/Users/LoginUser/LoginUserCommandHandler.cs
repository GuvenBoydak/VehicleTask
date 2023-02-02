using MediatR;
using VehicleTask.Application.DTOs;
using VehicleTask.Application.Helper;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.Services;

namespace VehicleTask.Application.Features.Command.Users.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Token>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<Token> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userRepository.GetByEmail(request.Email);

        if (currentUser == null)
            throw new InvalidOperationException($"{request.Email} User Not Found");

        if (!HashingHelper.VerifyPasswordHash(request.Password, currentUser.PasswordHash, currentUser.PasswordSalt))
            throw new InvalidOperationException("Wrong password");

        return _authService.CreateToken(currentUser);
    }
}