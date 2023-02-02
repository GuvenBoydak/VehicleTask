using MediatR;
using VehicleTask.Application.Helper;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.UnitOfWork;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Command.Users.RegisterUser;

public class RegisterUserCommandHandler : AsyncRequestHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userRepository.GetByEmail(request.Email);

        if (currentUser != null)
            throw new Exception($"{request.Email} User already exist");


        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
        var user = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }
}