using VehicleTask.Application.Intefaces.UnitOfWork;
using VehicleTask.Infrastructure.Context;

namespace VehicleTask.Infrastructure.UnitOfWork;

public class UnitOfWork:IUnitOfWork
{
    private readonly VehicleDbContext _dbContext;

    public UnitOfWork(VehicleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync()
    {
       await _dbContext.SaveChangesAsync();
    }
}