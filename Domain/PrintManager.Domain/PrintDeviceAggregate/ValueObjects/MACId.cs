using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

public sealed class MACId : ValueObject
{
    public Guid Value { get; }

    private MACId(Guid value)
    {
        Value = value;
    }
    public static MACId CreateFrom(Guid id) =>
        new(id);

    public static MACId CreateUnicId() =>
        new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
