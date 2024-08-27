using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.DepartmentAggregate.ValueObjects;

public sealed class PrintSessionId : ValueObject
{
    public Guid Value { get; private set; }

    private PrintSessionId(Guid value)
    {
        Value = value;
    }

    public static PrintSessionId CreateFrom(Guid id) =>
        new(id);
    public static PrintSessionId CreateUnicId() =>
        new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
