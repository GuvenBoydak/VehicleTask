using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Intefaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmail(string email);
}