using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;
using VehicleTask.Infrastructure.Context;

namespace VehicleTask.Infrastructure.Repositories;

public class UserRepository:GenericRepository<User>,IUserRepository
{
    public UserRepository(VehicleDbContext dbContext) : base(dbContext)
    {
    }
}