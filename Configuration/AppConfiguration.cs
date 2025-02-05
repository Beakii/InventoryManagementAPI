using InventoryManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace InventoryManagement.Configuration;

internal static class AppConfiguration
{
    public static void AddDataServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InventoryDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });
    }

    public static void AddSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Inventory Management API", Version = "v1" });
        });
    }
}