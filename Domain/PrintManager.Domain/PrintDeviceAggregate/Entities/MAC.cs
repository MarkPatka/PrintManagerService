using PrintManager.Domain.Common.Models;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;
using System.Net.NetworkInformation;

namespace PrintManager.Domain.PrintDeviceAggregate.Entities;

public sealed class MAC : Entity<MACId>
{
    public PhysicalAddress MacAddress { get; }
    public PrintDeviceId PrintDeviceId { get; }
#pragma warning disable CS8618
    private MAC() { }
#pragma warning disable CS8618

    private MAC(MACId id, PhysicalAddress address) 
        : base(id) 
    {
        MacAddress = address;
    }

    public static MAC Create(PhysicalAddress address) =>
        new(MACId.CreateUnicId(), address);
}
