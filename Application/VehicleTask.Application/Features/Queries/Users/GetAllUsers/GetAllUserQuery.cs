using MediatR;
using VehicleTask.Application.DTOs.Users;

namespace VehicleTask.Application.Features.Queries.Users.GetAllUsers;

public class GetAllUserQuery : IRequest<List<UserListDto>>
{
}