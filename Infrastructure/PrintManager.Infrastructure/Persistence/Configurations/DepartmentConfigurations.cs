using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrintManager.Domain.DepartmentAggregate;
using PrintManager.Domain.DepartmentAggregate.Entities;
using PrintManager.Domain.DepartmentAggregate.Enumerations;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Domain.InstallationAggregate.ValueObjects;
using PrintManager.Domain.InstallationAggregate;


namespace PrintManager.Infrastructure.Persistence.Configurations;

public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        ConfigureDepartmentTable(builder);
        ConfigureEmplyeesTable(builder);
        ConfigureDepartmentPrintDeviceTable(builder);
        ConfigurePrintSessionsTable(builder);
        ConfigureInstallationsTable(builder);
    }
    private void ConfigureInstallationsTable(EntityTypeBuilder<Department> builder)
    {
        builder.OwnsMany(b => b.Installations, ib =>
        {
            ib.ToTable(nameof(Installation));

            ib.HasKey(a => a.Id);

            ib.Property(a => a.Id)
                .HasConversion(
                    id => id.Value,
                    value => InstallationId.CreateFrom(value));

            ib.Property(a => a.Name)
                .HasMaxLength(100);

            ib.Property(a => a.DepartmentPrintDeviceId)
                .HasConversion(
                    id => id.Value,
                    value => DepartmentPrintDeviceId.CreateFrom(value));
        });
        builder.Navigation(d => d.Installations).Metadata.SetField("_installations");
        builder.Navigation(d => d.Installations).UsePropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigurePrintSessionsTable(EntityTypeBuilder<Department> builder)
    {
        builder.OwnsMany(x => x.PrintSessions, psb =>
        {
            psb.ToTable("Sessions");

            psb.HasKey(s => s.Id);

            psb.Property(s => s.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => PrintSessionId.CreateFrom(value));

            psb.Property(s => s.SessionStatus)
                .HasColumnType("tinyint")
                .HasConversion(
                    s => s.Code,
                    c => SessionStatus.GetStatus(c));

            psb.Property(s => s.SessionName)
                .HasMaxLength(100);
        });
    }
    private void ConfigureDepartmentPrintDeviceTable(EntityTypeBuilder<Department> builder)
    {
        builder.OwnsMany(d => d.PrintDevices, devb =>
        {
            devb.ToTable("DepartmentDevices");

            devb.WithOwner().HasForeignKey("DepartmentId");

            devb.HasKey(d => d.Id);

            devb.Property(d => d.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => DepartmentPrintDeviceId.CreateFrom(value));

            devb.Property(d => d.InnerName)
                .HasMaxLength(100);

            devb.Property(d => d.IsDefaultDevice)                
                .HasColumnType("bit")
                .HasDefaultValue(0);

            devb.Property(d => d.SerialNumber)
                .HasColumnType("tinyint")
                .HasDefaultValue(1);

            devb.Property(d => d.OriginalName)
                .HasMaxLength(100);

            devb.Property(d => d.ConnectionType)
                .IsRequired()
                .HasColumnType("tinyint")
                .HasConversion(
                    type => type.Code,
                    code => ConnectionType.GetStatus(code));

            devb.OwnsMany(d => d.MACs, mb =>
            {
                mb.ToTable("MACAddresses");

                mb.WithOwner().HasForeignKey("DepartmentPrintDeviceId");

                mb.HasKey(m => m.Id);

                mb.Property(m => m.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MACId.CreateFrom(value));

                mb.Property(m => m.MacAddress)
                    .HasColumnType("binary(6)")
                    .HasConversion<PhysicalAddressToBytesConverter>();

            });
            devb.Navigation(d => d.MACs).Metadata.SetField("_macs");
            devb.Navigation(d => d.MACs).UsePropertyAccessMode(PropertyAccessMode.Field);
        });
        //builder.Metadata.FindNavigation(nameof(DepartmentPrintDevice.MACs))!
        //    .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(d => d.PrintDevices).Metadata.SetField("_printDevices");
        builder.Navigation(d => d.PrintDevices).UsePropertyAccessMode(PropertyAccessMode.Field);        
    }
    private void ConfigureEmplyeesTable(EntityTypeBuilder<Department> builder)
    {
        builder.OwnsMany(d => d.Employees, eb =>
        {
            eb.ToTable("Employees");
            
            eb.WithOwner().HasForeignKey("DepartmentId");

            eb.HasKey("Id", "DepartmentId");

            eb.Property(e => e.Id)
                .HasColumnName("EmployeeId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => EmployeeId.CreateFrom(value));
            
            eb.Property(e => e.Name)
                .HasMaxLength(100);

            eb.Property(e => e.JobTitle)
                .HasMaxLength(100);
        });
        builder.Navigation(d => d.Employees).Metadata.SetField("_emplyees");
        builder.Navigation(d => d.Employees).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureDepartmentTable(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
    
        builder.HasKey(d => d.Id);
        
        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DepartmentId.CreateFrom(value));

        builder.Property(d => d.Name)
            .HasMaxLength(100);

        builder.Property(d => d.Address)
            .HasMaxLength(100);

        builder.Metadata.FindNavigation(nameof(Department.Installations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata.FindNavigation(nameof(Department.Employees))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.Metadata.FindNavigation(nameof(Department.PrintDevices))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata.FindNavigation(nameof(Department.PrintSessions))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
