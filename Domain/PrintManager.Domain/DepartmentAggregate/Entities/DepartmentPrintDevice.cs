using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.Enumerations;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;

namespace PrintManager.Domain.DepartmentAggregate.Entities;

public sealed class DepartmentPrintDevice : Entity<DepartmentPrintDeviceId>
{
    private readonly List<MAC> _macs = [];

    public string OriginalName { get; }

    public string InnerName { get; }

    public int SerialNumber { get; }

    public bool IsDefaultDevice { get; }

    public ConnectionType ConnectionType { get; }

    public IReadOnlyList<MAC> MACs => _macs.AsReadOnly();


#pragma warning disable CS8618
    private DepartmentPrintDevice() { }
#pragma warning disable CS8618

    private DepartmentPrintDevice(
        DepartmentPrintDeviceId id, 
        string innerName, 
        int serialNumber, 
        bool isDefaultDevice,
        string originalName,
        ConnectionType connection)
        : base(id)
    {
        InnerName = innerName;
        SerialNumber = serialNumber;
        IsDefaultDevice = isDefaultDevice;
        OriginalName = originalName;
        ConnectionType = connection;
    }

    public static DepartmentPrintDevice Create(string innerName, string originalName, ConnectionType type, int serialNumber, bool isDefaultDevice) =>
        new(DepartmentPrintDeviceId.CreateUnicId(), innerName, serialNumber, isDefaultDevice, originalName, type);
}


