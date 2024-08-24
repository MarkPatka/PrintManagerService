using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.DepartmentAggregate.ValueObjects;

public sealed class DepartmentId : ValueObject
{
    public Guid Value { get; set; }

    private DepartmentId(Guid value)
    {
        Value = value;
    }
    public static DepartmentId CreateFrom(Guid id) =>
        new(id);
    public static DepartmentId CreateUnicId() =>
        new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
