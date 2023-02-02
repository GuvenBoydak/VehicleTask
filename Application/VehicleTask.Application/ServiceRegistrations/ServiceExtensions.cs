using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VehicleTask.Application.Mapper;

namespace VehicleTask.Application.ServiceRegistrations;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection service)
    {
        service.AddMediatR(typeof(ServiceExtensions));

        var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MapperProfile()); });
        service.AddSingleton(mapperConfig.CreateMapper());

        return service;
    }
}