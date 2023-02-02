using AutoMapper;
using MediatR;
using VehicleTask.Application.DTOs.Colors;
using VehicleTask.Application.DTOs.Users;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Features.Queries.Users.GetAllUsers;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserListDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserListDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();

        return _mapper.Map<List<User>, List<UserListDto>>(users);
    }
}