using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.PrintSessionAggregate.ValueObjects;

public sealed class EmployeeId : ValueObject
{
    public Guid Value { get; }

    private EmployeeId(Guid value)
    {
        Value = value;
    }

    public static EmployeeId CreateFrom(Guid id) =>
        new(id);
    public static EmployeeId CreateUnic() =>
        new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
