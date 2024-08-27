using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Domain.InstallationAggregate.ValueObjects;

namespace PrintManager.Domain.InstallationAggregate;

public sealed class Installation : AggregateRoot<InstallationId>
{
    public string Name { get; }
    public DepartmentPrintDeviceId DepartmentPrintDeviceId { get; }

#pragma warning disable CS8618
    private Installation() { }
#pragma warning disable CS8618

    private Installation(InstallationId id, string name, DepartmentPrintDeviceId departmentPrintDeviceId)
        : base(id)
    {
        Name = name;
        DepartmentPrintDeviceId = departmentPrintDeviceId;
    }

    public static Installation Create(string name, DepartmentPrintDeviceId departmentPrintDeviceId) =>
        new(InstallationId.CreateUnicId(), name, departmentPrintDeviceId);

}
