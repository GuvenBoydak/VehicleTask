using FluentValidation.AspNetCore;
using VehicleTask.API.Filters;
using VehicleTask.API.SwaggerRegistration;
using VehicleTask.Application.ServiceRegistrations;
using VehicleTask.Application.Validations.Users;
using VehicleTask.Infrastructure.ServiceRegistrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Fluent Validation
builder.Services.AddControllers(option => option.Filters.Add<ValidationFilter>()).AddFluentValidation(x =>
    x.RegisterValidatorsFromAssemblyContaining(typeof(RegisterUserCommandValidator)));

//Swagger Authentication
SwaggerShemeInjection.SwaggerShemeServiceInjection(builder.Services);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastractureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}