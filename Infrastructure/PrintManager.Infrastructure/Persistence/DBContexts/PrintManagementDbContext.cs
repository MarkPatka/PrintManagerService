using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrintManager.Domain.DepartmentAggregate;
using PrintManager.Domain.DepartmentAggregate.Entities;
using PrintManager.Domain.PrintDeviceAggregate;
using PrintManager.Domain.PrintSessionAggregate;

namespace PrintManager.Infrastructure.Persistence.DBContexts;

public class PrintManagementDbContext : DbContext
{
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<PrintDevice> PrintDevices { get; set; } = null!;
    public DbSet<PrintSession> Sessions{ get; set; } = null!;

    public PrintManagementDbContext(DbContextOptions<PrintManagementDbContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(PrintManagementDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
