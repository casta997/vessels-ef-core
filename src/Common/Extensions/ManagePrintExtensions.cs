using Common;

namespace Microsoft.Extensions.DependencyInjection;

public static class ManagePrintExtensions
{
    public static IServiceCollection AddCommon(this IServiceCollection services)
    {
        services
            .AddTransient<IManagePrint, ManagePrint>();
        return services;
    }
}
