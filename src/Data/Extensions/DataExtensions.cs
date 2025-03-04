using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, string connectionString)
    {
        services.AddTransient<IVesselRepository, VesselRepository>()
                .AddDbContext<MaritimeContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Data")));
        return services;
    }
}
