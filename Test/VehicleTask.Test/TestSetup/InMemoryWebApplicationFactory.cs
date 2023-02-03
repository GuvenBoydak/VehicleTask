using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehicleTask.Infrastructure.Context;

namespace VehicleTask.Test.TestSetup;

public class InMemoryWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing")
            .ConfigureTestServices(services =>
            {
                var options = new DbContextOptionsBuilder<VehicleDbContext>()
                    .UseInMemoryDatabase("InMemoryTest").Options;
                ServiceCollectionServiceExtensions.AddScoped<VehicleDbContext>(services,
                    provider => new VehicleTestContext(options));

                var serviceProvider = ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services);
                using var scope = serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<VehicleDbContext>();
                db.Database.EnsureCreated();
            });
    }
}