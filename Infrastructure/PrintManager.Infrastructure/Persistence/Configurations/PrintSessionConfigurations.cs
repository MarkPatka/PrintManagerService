using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintManager.Domain.DepartmentAggregate.Entities;
using PrintManager.Domain.PrintSessionAggregate;
using PrintManager.Domain.PrintSessionAggregate.Enumerations;
using PrintManager.Domain.PrintSessionAggregate.ValueObjects;

namespace PrintManager.Infrastructure.Persistence.Configurations;

public class PrintSessionConfigurations : IEntityTypeConfiguration<PrintSession>
{
    public void Configure(EntityTypeBuilder<PrintSession> builder)
    {
        ConfigurePrintSessionTable(builder);
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
            .HasColumnType("tinyint")
            .HasConversion(
                s => s.Code,
                c => SessionStatus.GetStatus(c));     

        builder.Property(s => s.SessionName)
            .HasMaxLength(100);

        //builder.HasOne(s => s.PrintDevice).WithOne()
        //    .HasForeignKey<DepartmentPrintDevice>(p => p.Id);
        //builder.Navigation(s => s.PrintDevice).IsRequired();
        
        //builder.HasOne(s => s.PrintingEmployee).WithOne()
        //    .HasForeignKey<Employee>(p => p.Id);
        //builder.Navigation(s => s.PrintingEmployee).IsRequired();

        //builder.OwnsOne(s => s.PrintDevice);
        //builder.OwnsOne(s => s.PrintingEmployee);
    }
}
