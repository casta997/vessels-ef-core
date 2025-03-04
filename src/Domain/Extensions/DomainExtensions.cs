using Domain;

namespace Microsoft.Extensions.DependencyInjection;

public static class DomainExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services
            .AddTransient<IRecordManagerService, OwnerService>()
            .AddTransient<IRecordManagerService, VesselService>();
        return services;
    }
}
