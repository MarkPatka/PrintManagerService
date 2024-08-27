using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.Enumerations;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;

namespace PrintManager.Domain.DepartmentAggregate.Entities;

public sealed class PrintSession : AggregateRoot<PrintSessionId>
{
    public string SessionName { get; }
    public int Pages { get; }
    public SessionStatus SessionStatus { get; }

#pragma warning disable CS8618
    private PrintSession() { }
#pragma warning disable CS8618

    private PrintSession(PrintSessionId id, string name, int pages, SessionStatus status)
        : base(id)
    {
        SessionName = name;
        Pages = pages;
        SessionStatus = status;
    }

    public static PrintSession Create(string name, int pages, SessionStatus status) =>
        new(PrintSessionId.CreateUnicId(), name, pages, status);
}
