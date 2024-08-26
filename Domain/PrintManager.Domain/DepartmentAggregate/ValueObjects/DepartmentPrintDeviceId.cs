using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.DepartmentAggregate.ValueObjects;

public sealed class DepartmentPrintDeviceId : ValueObject
{
    public Guid Value { get; private set; }

    private DepartmentPrintDeviceId(Guid value)
    {
        Value = value;
    }

    public static DepartmentPrintDeviceId CreateFrom(Guid id) =>
        new(id);
    public static DepartmentPrintDeviceId CreateUnicId() =>
        new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

