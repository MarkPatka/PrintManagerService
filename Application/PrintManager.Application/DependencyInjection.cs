using Microsoft.Extensions.DependencyInjection;

namespace PrintManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        ///...
        return services;
    }
}
