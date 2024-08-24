using PrintManager.Domain.Common.Models;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;
using System.Net.NetworkInformation;

namespace PrintManager.Domain.PrintDeviceAggregate.Entities;

public sealed class MACList : Entity<MACListId>
{
    private readonly List<PhysicalAddress> _macs = [];
    public IReadOnlyList<PhysicalAddress> MACs => _macs.AsReadOnly();

#pragma warning disable CS8618
    private MACList() { }
#pragma warning disable CS8618

    private MACList(MACListId id, List<PhysicalAddress> addresses) 
        : base(id)
    {
        _macs = addresses;
    }

    public static MACList Create(List<PhysicalAddress> addresses) =>
        new(MACListId.CreateUnicId(), addresses);
}
