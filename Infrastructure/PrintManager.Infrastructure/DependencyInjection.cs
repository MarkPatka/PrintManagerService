using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Infrastructure.Persistence.DBContexts;
using PrintManager.Infrastructure.Persistence.Repositories;

namespace PrintManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        AddPersistence(services);
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContextPool<PrintManagementDbContext>(options => 
            options.UseSqlServer());

        services.AddScoped<IEmployeeRepository, EmployeeRepository>()
            .AddScoped<IEmployeeRepository, EmployeeRepository>()
            .AddScoped<IDepartmentRepository, DepartmentRepository>()
            .AddScoped<IPrintDeviceRepository, PrintDeviceRepository>()
            .AddScoped<IPrintSessionRepository, PrintSessionRepository>();

        return services;
    }
}
