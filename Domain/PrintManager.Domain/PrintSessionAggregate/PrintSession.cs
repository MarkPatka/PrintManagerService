using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.Entities;
using PrintManager.Domain.PrintSessionAggregate.Enumerations;
using PrintManager.Domain.PrintSessionAggregate.ValueObjects;

namespace PrintManager.Domain.PrintSessionAggregate;

public sealed class PrintSession : AggregateRoot<PrintSessionId>
{
    public string SessionName { get; }
    public int Pages { get; }

    public SessionStatus SessionStatus { get; }

    //public DepartmentPrintDevice PrintDevice { get; private set; }
    //public Employee PrintingEmployee { get; private set; }

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
