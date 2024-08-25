using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintManager.Domain.DepartmentAggregate;
using PrintManager.Domain.DepartmentAggregate.Entities;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

namespace PrintManager.Infrastructure.Persistence.Configurations;

public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        ConfigureDepartmentTable(builder);
        ConfigureEmplyeesTable(builder);
        ConfigureDepartmentPrintDeviceTable(builder);
    }

    private void ConfigureDepartmentPrintDeviceTable(EntityTypeBuilder<Department> builder)
    {
        builder.OwnsMany(d => d.PrintDevices, devb =>
        {
            devb.ToTable("InnerDepartmentDevices");

            devb.WithOwner().HasForeignKey("DepartmentId");

            devb.HasKey(nameof(DepartmentPrintDevice.Id),"Id", "DepartmentId");

            devb.Property(d => d.Id)
                .HasColumnName("DepartmentDeviceId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => DepartmentPrintDeviceId.CreateFrom(value));

            devb.Property(d => d.InnerName)
                .HasMaxLength(100);

            devb.Property(d => d.IsDefaultDevice)                
                .HasColumnType("bit")
                .HasDefaultValue(0);

            devb.Property(d => d.DeviceId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => PrintDeviceId.CreateFrom(value));

            devb.Property(d => d.SerialNumber)
                .HasColumnType("tinyint")
                .HasDefaultValue(1);                
        });
        builder.Navigation(d => d.PrintDevices).Metadata.SetField("_printDevices");
        builder.Navigation(d => d.PrintDevices).UsePropertyAccessMode(PropertyAccessMode.Field);

    }

    private void ConfigureEmplyeesTable(EntityTypeBuilder<Department> builder)
    {
        builder.OwnsMany(d => d.Employees, eb =>
        {
            eb.ToTable("Employees");
            
            eb.WithOwner().HasForeignKey("DepartmentId");

            eb.HasKey(nameof(Employee.Id), "Id", "DepartmentId");

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
        
        builder.Metadata.FindNavigation(nameof(Department.Employees))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        
        builder.Metadata.FindNavigation(nameof(Department.PrintDevices))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
