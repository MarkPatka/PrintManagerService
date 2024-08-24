using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

public sealed class MACListId : ValueObject
{
    public Guid Value { get; }

    private MACListId(Guid value)
    {
        Value = value;
    }

    public static MACListId CreateUnicId() =>
        new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
