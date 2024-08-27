using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrintManager.Domain.DepartmentAggregate;
using PrintManager.Domain.DepartmentAggregate.Entities;
using PrintManager.Infrastructure.Persistence.Configurations;

namespace PrintManager.Infrastructure.Persistence.DBContexts;

public class PrintManagementDbContext : DbContext
{
    public PrintManagementDbContext(DbContextOptions<PrintManagementDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(DepartmentConfigurations).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
