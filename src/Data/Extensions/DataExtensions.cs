using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, string connectionString)
    {
        services
            .AddTransient<IOwnerRepository, OwnerRepository>()
            .AddTransient<IVesselRepository, VesselRepository>()
            .AddDbContext<MaritimeContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Data")));
        //EnableSensitiveDataLogging - Search about this function
        //.AddDbContext<MaritimeContext>(options => options.EnableSensitiveDataLogging().UseSqlServer(connectionString, b => b.MigrationsAssembly("Data")));
        return services;
    }
}
