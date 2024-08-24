using PrintManager.Domain.Common.Models;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

namespace PrintManager.Domain.PrintDeviceAggregate.Entities;

public sealed class PrintDeviceOfDepartment : Entity<PrintDeviceOfDepartmentId>
{
    public string InnerName { get; }
    public int SerialNumber { get; }
    public bool IsDefaultDevice { get; }

#pragma warning disable CS8618
    private PrintDeviceOfDepartment() { }
#pragma warning disable CS8618

    private PrintDeviceOfDepartment(PrintDeviceOfDepartmentId id, string innerName, int serialNumber, bool isDefaultDevice) 
        : base(id)
    {
        InnerName = innerName;
        SerialNumber = serialNumber;
        IsDefaultDevice = isDefaultDevice;
    }

    public static PrintDeviceOfDepartment Create(string innerName, int serialNumber, bool isDefaultDevice) =>
        new(PrintDeviceOfDepartmentId.CreateUnicId(), innerName, serialNumber, isDefaultDevice);
}


