using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Infrastructure.Context;
using Color = VehicleTask.Domain.Models.Concrete.Color;

namespace VehicleTask.Infrastructure.Repositories;

public class ColorRepository : GenericRepository<Color>,IColorRepository
{
    public ColorRepository(VehicleDbContext dbContext) : base(dbContext)
    {
    }
}