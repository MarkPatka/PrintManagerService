using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrintManager.Domain.PrintDeviceAggregate;

namespace PrintManager.Infrastructure.Persistence.DBContexts;

public class PrintManagementDbContext : DbContext
{
    public DbSet<PrintDevice> PrintDevices { get; set; } = null!;

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

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrintManagementDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
