using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

namespace PrintManager.Domain.DepartmentAggregate.Entities;

public sealed class DepartmentPrintDevice : Entity<DepartmentPrintDeviceId>
{
    public string InnerName { get; }

    public int SerialNumber { get; }

    public bool IsDefaultDevice { get; }

    public PrintDeviceId DeviceId { get; private set; }
    public DepartmentId DepartmentId { get; private set; }

#pragma warning disable CS8618
    private DepartmentPrintDevice() { }
#pragma warning disable CS8618

    private DepartmentPrintDevice(DepartmentPrintDeviceId id, string innerName, int serialNumber, bool isDefaultDevice)
        : base(id)
    {
        InnerName = innerName;
        SerialNumber = serialNumber;
        IsDefaultDevice = isDefaultDevice;
    }

    public static DepartmentPrintDevice Create(string innerName, int serialNumber, bool isDefaultDevice) =>
        new(DepartmentPrintDeviceId.CreateUnicId(), innerName, serialNumber, isDefaultDevice);
}


