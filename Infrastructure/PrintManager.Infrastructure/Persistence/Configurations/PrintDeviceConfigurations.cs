using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrintManager.Domain.PrintDeviceAggregate;
using PrintManager.Domain.PrintDeviceAggregate.Entities;
using PrintManager.Domain.PrintDeviceAggregate.Enumerations;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

namespace PrintManager.Infrastructure.Persistence.Configurations;

public class PrintDeviceConfigurations : IEntityTypeConfiguration<PrintDevice>
{
    public void Configure(EntityTypeBuilder<PrintDevice> builder)
    {
        ConfigurePrintDeviceTable(builder);
        ConfigureMacListTable(builder);
    }

    private void ConfigureMacListTable(EntityTypeBuilder<PrintDevice> builder)
    {
        builder.OwnsMany(d => d.MACs, mb =>
        {
            mb.ToTable("MACAddresses");
            
            mb.WithOwner().HasForeignKey("PrintDeviceId");

            mb.HasKey(nameof(MAC.Id), "Id", "PrintDeviceId");

            mb.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MACId.CreateFrom(value));

            mb.Property(m => m.MacAddress)
                .HasColumnType("binary(6)")
                .HasConversion<PhysicalAddressToBytesConverter>();
        });
        builder.Navigation(d => d.MACs).Metadata.SetField("_macs");
        builder.Navigation(d => d.MACs).UsePropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigurePrintDeviceTable(EntityTypeBuilder<PrintDevice> builder)
    {
        builder.ToTable("PrintingDevices");
        
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PrintDeviceId.CreateFrom(value));
        
        builder.Property(b => b.Name)
            .HasMaxLength(100);

        builder.Property(b => b.ConnectionType)
            .IsRequired()
            .HasColumnType("tinyint")
            .HasConversion(
                type => type.Code,
                code => ConnectionType.GetStatus(code));

        builder.Metadata.FindNavigation(nameof(PrintDevice.MACs))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
