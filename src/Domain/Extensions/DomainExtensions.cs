using Common;
using Domain;

namespace Microsoft.Extensions.DependencyInjection;

public static class DomainExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
        => services.AddTransient<IVesselService, VesselService>()
                   .AddTransient<IMenuService, MenuService>()
                   .AddTransient<IHumanMachineInterface, HumanMachine>();   
}
