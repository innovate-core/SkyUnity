using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkyUnityCore;

namespace SkyUnityServer.Extensions;

public static class DbContextExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connetctionString = configuration.GetConnectionString("AppConnection");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connetctionString, builder =>
        {
            builder.MigrationsAssembly("SkyUnityCore");
            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(3), null);
        }));

        return services;
    }
}
