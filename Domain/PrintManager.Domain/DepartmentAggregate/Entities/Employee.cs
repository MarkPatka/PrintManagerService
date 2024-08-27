using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;

namespace PrintManager.Domain.DepartmentAggregate.Entities;

public sealed class Employee : Entity<EmployeeId>
{
    public string Name { get; }
    public string JobTitle { get; }

#pragma warning disable CS8618
    private Employee() { }
#pragma warning disable CS8618

    private Employee(EmployeeId id, string name, string title)
        : base(id)
    {
        Name = name;
        JobTitle = title;
    }

    public static Employee Create(string name, string title) =>
        new(EmployeeId.CreateUnic(), name, title);
}
