using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Application.Intefaces.Services;
using VehicleTask.Application.Intefaces.UnitOfWork;
using VehicleTask.Infrastructure.Context;
using VehicleTask.Infrastructure.Repositories;
using VehicleTask.Infrastructure.Services;

namespace VehicleTask.Infrastructure.ServiceRegistrations;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastractureServices(this IServiceCollection service,
        IConfiguration configuration)
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


        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("SecurityKey").Value))
                };
            });

        return service;
    }
}