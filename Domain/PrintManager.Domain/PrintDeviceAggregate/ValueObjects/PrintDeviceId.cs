using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

public sealed class PrintDeviceId : ValueObject
{
    public Guid Value { get; set; }

    private PrintDeviceId(Guid value)
    {
        Value = value;
    }

    public static PrintDeviceId CreateUnicId() =>
        new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
