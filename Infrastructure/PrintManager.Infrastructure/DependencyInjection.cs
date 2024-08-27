using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Application.Common.Interfaces.Services;
using PrintManager.Infrastructure.Persistence.DBContexts;
using PrintManager.Infrastructure.Persistence.Repositories;
using PrintManager.Infrastructure.Services;

namespace PrintManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration dbconfiguration)
    {
        services
            .AddRepositories()
            .AddPersistence(dbconfiguration)
            .AddServices();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, 
        IConfiguration configuration)
    {
        var type = configuration.GetSection("MSSQL");

        services.AddDbContextFactory<PrintManagementDbContext>(options => 
            options.UseSqlServer(type.GetConnectionString("PrintManagementDb"), 
                    sqlOptions => sqlOptions.MigrationsAssembly("PrintManager.Infrastructure")),
                    ServiceLifetime.Scoped);

        return services;
    }
    
    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddScoped<IInstallationService, InstallationService>();

    private static IServiceCollection AddRepositories(this IServiceCollection servcies) =>
        servcies.AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IDepartmentRepository, DepartmentRepository>()
                .AddScoped<IPrintDeviceRepository, PrintDeviceRepository>()
                .AddScoped<IPrintSessionRepository, PrintSessionRepository>()
                .AddScoped<IInstallationRepository, InstallationRepository>();
}
