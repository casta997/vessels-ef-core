using Domain;

namespace Microsoft.Extensions.DependencyInjection;

public static class DomainExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services
            .AddTransient<IRecordManagerService<OwnerService>, OwnerService>()
            .AddTransient<IRecordManagerService<VesselService>, VesselService>();
        return services;
    }
}
