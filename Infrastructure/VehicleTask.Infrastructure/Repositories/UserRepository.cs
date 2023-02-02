using Microsoft.EntityFrameworkCore;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;
using VehicleTask.Infrastructure.Context;

namespace VehicleTask.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(VehicleDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User> GetByEmail(string email)
    {
        return await Table.FirstOrDefaultAsync(x => x.Email == email);
    }
}