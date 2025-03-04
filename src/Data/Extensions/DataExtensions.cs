using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MaritimeContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Data")));
        return services;
    }
}
