using Microsoft.Extensions.Configuration;

namespace VehicleTask.Infrastructure;

public static class Configuration
{
    public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();

                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/VehicleTask.Api"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("PostgreSql");
            }
        }
}