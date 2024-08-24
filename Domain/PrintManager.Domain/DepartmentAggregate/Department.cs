using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

namespace PrintManager.Domain.DepartmentAggregate;

public sealed class Department : AggregateRoot<DepartmentId>
{
    public string Name { get; }
    public string Address { get; }

    public List<PrintDeviceId> PrintDevices { get; } = [];

#pragma warning disable CS8618
    private Department() { }
#pragma warning disable CS8618

    private Department(
        DepartmentId id, 
        string name, string address,
        List<PrintDeviceId> printDevices) 
        : base(id)
    {
        Name = name;
        Address = address;
        PrintDevices = printDevices;
    }

    public static Department Create(string name, string address, List<PrintDeviceId> printDevices) =>
        new(DepartmentId.CreateUnicId(), name, address, printDevices);
}
