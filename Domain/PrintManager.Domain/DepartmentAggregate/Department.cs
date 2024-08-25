using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.Entities;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;

namespace PrintManager.Domain.DepartmentAggregate;

public sealed class Department : AggregateRoot<DepartmentId>
{
    private readonly List<Employee> _emplyees = [];
    private readonly List<DepartmentPrintDevice> _printDevices = [];

    public string Name { get; }
    public string Address { get; }

    public IReadOnlyList<Employee> Employees => _emplyees.AsReadOnly();
    public IReadOnlyList<DepartmentPrintDevice> PrintDevices => _printDevices.AsReadOnly();

#pragma warning disable CS8618
    private Department() { }
#pragma warning disable CS8618

    private Department(DepartmentId id, string name, string address) 
        : base(id)
    {
        Name = name;
        Address = address;
    }

    public static Department Create(string name, string address) =>
        new(DepartmentId.CreateUnicId(), name, address);
}
