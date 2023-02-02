using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Concrete;
using VehicleTask.Infrastructure.Context;

namespace VehicleTask.Infrastructure.Repositories;

public class CarRepository:GenericRepository<Car>,ICarRepository
{
    public CarRepository(VehicleDbContext dbContext) : base(dbContext)
    {
    }
}