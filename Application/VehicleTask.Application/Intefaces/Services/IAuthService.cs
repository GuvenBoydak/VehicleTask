using VehicleTask.Application.DTOs;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Intefaces.Services;

public interface IAuthService
{
    Token CreateToken(User user);
}