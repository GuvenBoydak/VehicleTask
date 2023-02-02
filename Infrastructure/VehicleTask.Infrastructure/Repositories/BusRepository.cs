using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;
using VehicleTask.Infrastructure.Context;

namespace VehicleTask.Infrastructure.Repositories;

public class BusRepository:GenericRepository<Bus>,IBusRepository
{
    public BusRepository(VehicleDbContext dbContext) : base(dbContext)
    {
    }
}