using App.Wiz.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Wiz.Infrastructure;

public static class Startup
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                       IConfiguration configuration)
    {
        string? connnectionString = configuration.GetConnectionString("DefaultConnection");
        _ = services.AddDatabse(connnectionString);
        _ = services.AddScoped(provider => provider.GetRequiredService<CatalystWizDbContext>());
        return services;
    }

    private static IServiceCollection AddDatabse(this IServiceCollection services, string connnectionString)
    {

        _ = services.AddDbContext<CatalystWizDbContext>(
            (options) => {
                _ = options.UseSqlServer(connnectionString);
            }
        );
        return services;
    }
}
