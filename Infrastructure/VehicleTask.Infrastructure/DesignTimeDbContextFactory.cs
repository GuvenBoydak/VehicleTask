using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VehicleTask.Infrastructure.Context;

namespace VehicleTask.Infrastructure;

internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<VehicleDbContext>
{
    public VehicleDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<VehicleDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
        return new VehicleDbContext(dbContextOptionsBuilder.Options);
    }
}