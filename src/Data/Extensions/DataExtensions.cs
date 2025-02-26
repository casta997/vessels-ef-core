using Data.Entities;
using Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
        => services.AddTransient<IVesselRepository, VesselRepository>()
                   .AddTransient<IOwnerRepository, OwnerRepository>()
                   .AddDbContext<MaritimeContext>();
}
