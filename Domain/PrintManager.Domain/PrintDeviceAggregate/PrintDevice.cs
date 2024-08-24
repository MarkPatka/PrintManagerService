using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Domain.PrintDeviceAggregate.Enumerations;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

namespace PrintManager.Domain.PrintDeviceAggregate;

public sealed class PrintDevice : AggregateRoot<PrintDeviceId>
{
    public string Name { get; }
    
    public ConnectionType ConnectionType { get; }

    public MACListId MACids { get; }

    public DepartmentId DepartmentId { get; }

    public PrintDeviceOfDepartmentId PrintDeviceOfDepartment { get; }

#pragma warning disable CS8618
    private PrintDevice() { }
#pragma warning disable CS8618

    private PrintDevice(
        PrintDeviceId id, 
        string name, 
        ConnectionType connection,
        DepartmentId departmentId,
        PrintDeviceOfDepartmentId printDeviceOfDepartment,
        MACListId macIds) 
        : base(id)
    {
        Name = name;
        ConnectionType = connection;
        MACids = macIds;
        DepartmentId = departmentId;
        PrintDeviceOfDepartment = printDeviceOfDepartment;
    }
    
    public static PrintDevice Create(string name, 
        ConnectionType connection,  DepartmentId departmentId,
        PrintDeviceOfDepartmentId printDeviceOfDepartment, MACListId macIds) =>
            new(PrintDeviceId.CreateUnicId(), name, connection, departmentId, printDeviceOfDepartment, macIds);
}
