using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

public sealed class PrintDeviceOfDepartmentId : ValueObject
{
    public Guid Value { get; }

    private PrintDeviceOfDepartmentId(Guid value)
    {
        Value = value;
    }

    public static PrintDeviceOfDepartmentId CreateUnicId() =>
        new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

