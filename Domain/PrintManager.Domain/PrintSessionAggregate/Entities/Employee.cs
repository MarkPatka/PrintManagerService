using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Domain.PrintSessionAggregate.ValueObjects;

namespace PrintManager.Domain.PrintSessionAggregate.Entities;

public sealed class Employee : Entity<EmployeeId>
{
    public string Name { get; }
    public string JobTitle { get; }
    public DepartmentId DepartmentId { get; }

#pragma warning disable CS8618
    private Employee() { }
#pragma warning disable CS8618

    private Employee(EmployeeId id, string name, string title, DepartmentId departmentId) 
        : base(id) 
    {
        Name = name;
        JobTitle = title;
        DepartmentId = departmentId;
    }

    public static Employee Create(string name, string title, DepartmentId departmentId) =>
        new(EmployeeId.CreateUnic(), name, title, departmentId);
}
