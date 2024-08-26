using PrintManager.Domain.Common.Models;
using PrintManager.Domain.PrintDeviceAggregate.Entities;
using PrintManager.Domain.PrintDeviceAggregate.Enumerations;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

namespace PrintManager.Domain.PrintDeviceAggregate;

public sealed class PrintDevice : AggregateRoot<PrintDeviceId>
{
    private readonly List<MAC> _macs = [];

    public string Name { get; }    

    public ConnectionType ConnectionType { get; }

    public IReadOnlyList<MAC> MACs => _macs.AsReadOnly();

#pragma warning disable CS8618
    private PrintDevice() { }
#pragma warning disable CS8618

    private PrintDevice(PrintDeviceId id, string name, ConnectionType connection) 
        : base(id)
    {
        Name = name;
        ConnectionType = connection;
    }
    
    public static PrintDevice Create(string name, ConnectionType connection) =>
            new(PrintDeviceId.CreateUnicId(), name, connection);
}
