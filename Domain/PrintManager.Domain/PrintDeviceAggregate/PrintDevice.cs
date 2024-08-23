using PrintManager.Domain.Common.Models;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Domain.PrintDeviceAggregate.Enumerations;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;
using System.Net.NetworkInformation;

namespace PrintManager.Domain.PrintDeviceAggregate;

public sealed class PrintDevice : AggregateRoot<PrintDeviceId>
{
    private readonly List<PhysicalAddress>? MACs = [];

    public string Name { get; }
    
    public ConnectionType ConnectionType { get; }

    public DepartmentId DepartmentId { get; }

    public IReadOnlyList<PhysicalAddress>? MACAddresses => MACs?.AsReadOnly();

    private PrintDevice(PrintDeviceId id, string name, ConnectionType connection) 
        : base(id)
    {
        Name = name;
        ConnectionType = connection;
    }
    
    public static PrintDevice Create(string name, ConnectionType connection) =>
        new(PrintDeviceId.CreateUnicId(), name, connection);
}
