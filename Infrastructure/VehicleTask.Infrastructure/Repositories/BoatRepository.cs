using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;
using VehicleTask.Infrastructure.Context;

namespace VehicleTask.Infrastructure.Repositories;

public class BoatRepository:GenericRepository<Boat>,IBoatRepository
{
    public BoatRepository(VehicleDbContext dbContext) : base(dbContext)
    {
    }
}