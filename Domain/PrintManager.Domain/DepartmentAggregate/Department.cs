using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Domain.PrintDeviceAggregate;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

namespace PrintManager.Domain.DepartmentAggregate;

public sealed class Department : AggregateRoot<DepartmentId>
{
    public string Name { get; }
    public string Address { get; }
    public string Email { get; }

    public List<PrintDeviceId> PrintDevices { get; } = [];

    private Department(
        DepartmentId id, 
        string name, string address, string email, 
        List<PrintDeviceId> printDevices) 
        : base(id)
    {
        Name = name;
        Address = address;
        Email = email;
        PrintDevices = printDevices;
    }

    public static Department Create(string name, string address, string email, List<PrintDeviceId> printDevices) =>
        new(DepartmentId.CreateUnicId(), name, address, email, printDevices);
}
