using App.Wiz.Common.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace App.Wiz.Common;

public static class Startup
{
    public static IServiceCollection AddCommon(this IServiceCollection services)
    {
        _ = services.AddServices();
        return services;
    }
    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        _ = services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}
