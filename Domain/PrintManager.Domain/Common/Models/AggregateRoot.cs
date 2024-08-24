namespace PrintManager.Domain.Common.Models;

public abstract class AggregateRoot<Tid> : Entity<Tid>
    where Tid : notnull
{
    protected AggregateRoot(Tid id) : base(id) { }

#pragma warning disable CS8618
    protected AggregateRoot() { }
#pragma warning disable CS8618
}
