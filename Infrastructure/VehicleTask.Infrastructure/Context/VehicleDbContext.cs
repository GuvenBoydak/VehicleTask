using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Infrastructure.Context;

public class VehicleDbContext : DbContext
{
    public VehicleDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Boat> Boats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Assembly'deki IEntityTypeConfiguration'den implement'e edilen classları reflection sayesinde buluyor.
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}