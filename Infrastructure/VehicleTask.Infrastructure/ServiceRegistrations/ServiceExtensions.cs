using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.Services;
using VehicleTask.Application.Intefaces.UnitOfWork;
using VehicleTask.Infrastructure.Context;
using VehicleTask.Infrastructure.Repositories;
using VehicleTask.Infrastructure.Services;

namespace VehicleTask.Infrastructure.ServiceRegistrations;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastractureServices(this IServiceCollection service)
    {
        service.AddDbContext<VehicleDbContext>(opt => opt.UseNpgsql(Configuration.ConnectionString));

        service.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        service.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<IColorRepository, ColorRepository>();
        service.AddScoped<ICarRepository, CarRepository>();
        service.AddScoped<IBusRepository, BusRepository>();
        service.AddScoped<IBoatRepository, BoatRepository>();
        service.AddScoped<IAuthService, AuthService>();

        return service;
    }
}