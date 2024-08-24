using PrintManager.Domain.Common.Models;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;
using PrintManager.Domain.PrintSessionAggregate.Entities;
using PrintManager.Domain.PrintSessionAggregate.Enumerations;
using PrintManager.Domain.PrintSessionAggregate.ValueObjects;

namespace PrintManager.Domain.PrintSessionAggregate;

public sealed class PrintSession : AggregateRoot<PrintSessionId>
{
    public string SessionName { get; }

    public int Pages { get; }

    public SessionStatus SessionStatus { get; }

    public PrintDeviceId PrintDeviceId { get; }

    public Employee PrintingEmployee { get; }

#pragma warning disable CS8618
    private PrintSession() { }
#pragma warning disable CS8618

    private PrintSession(PrintSessionId id, string name, int pages, SessionStatus status, Employee printingEmployee) 
        : base(id)
    {
        SessionName = name;
        Pages = pages;
        SessionStatus = status;
        PrintingEmployee = printingEmployee;
    }

    public static PrintSession Create(string name, int pages, SessionStatus status, Employee printingEmployee) =>
        new(PrintSessionId.CreateUnicId(), name, pages, status, printingEmployee);
}
