using PrintManager.Domain.Common.Models;

namespace PrintManager.Domain.InstallationAggregate.ValueObjects;

public sealed class InstallationId : ValueObject
{
    public Guid Value { get; private set; }

    private InstallationId(Guid value)
    {
        Value = value;
    }
    public static InstallationId CreateFrom(Guid id) =>
        new(id);
    public static InstallationId CreateUnicId() =>
        new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
