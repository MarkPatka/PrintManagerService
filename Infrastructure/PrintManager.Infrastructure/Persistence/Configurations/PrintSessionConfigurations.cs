using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;
using PrintManager.Domain.PrintSessionAggregate;
using PrintManager.Domain.PrintSessionAggregate.Entities;
using PrintManager.Domain.PrintSessionAggregate.Enumerations;
using PrintManager.Domain.PrintSessionAggregate.ValueObjects;

namespace PrintManager.Infrastructure.Persistence.Configurations;

public class PrintSessionConfigurations : IEntityTypeConfiguration<PrintSession>
{
    public void Configure(EntityTypeBuilder<PrintSession> builder)
    {
        ConfigurePrintSessionTable(builder);
        ConfigureEmployeesTable(builder);
    }

    private void ConfigureEmployeesTable(EntityTypeBuilder<PrintSession> builder)
    {
        builder.OwnsOne(e => e.PrintingEmployee, eb =>
        {
            eb.ToTable("Employess");

            eb.WithOwner().HasForeignKey("PrintSessionId");

            eb.Property(p => p.Id)
                .HasColumnName("EmployeeId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => EmployeeId.CreateFrom(value));

            eb.HasKey("Id", "PrintSessionId");

            eb.Property(p => p.Name)
                .HasMaxLength(100);

            eb.Property(p => p.JobTitle)
                .HasMaxLength(100);

            eb.Property(p => p.DepartmentId)
                .HasConversion(
                    id => id.Value,
                    value => DepartmentId.CreateFrom(value));

        });
        //builder.Metadata.FindNavigation();
    }

    private void ConfigurePrintSessionTable(EntityTypeBuilder<PrintSession> builder)
    {
        builder.ToTable("Sessions");
        
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PrintSessionId.CreateFrom(value));

        builder.Property(s => s.SessionStatus)
            .IsRequired()
            .HasConversion(
                s => s.Code,
                c => SessionStatus.GetStatus(c));

        builder.Property(s => s.PrintDeviceId)
            .IsRequired()
            .HasConversion(
                id => id.Value,
                value => PrintDeviceId.CreateFrom(value));

        builder.OwnsOne(s => s.PrintingEmployee);

        builder.Property(s => s.SessionName)
            .HasMaxLength(100);
    }
}
