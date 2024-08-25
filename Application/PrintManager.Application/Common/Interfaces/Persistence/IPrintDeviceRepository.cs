using PrintManager.Domain.PrintDeviceAggregate;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

namespace PrintManager.Application.Common.Interfaces.Persistence;

public interface IPrintDeviceRepository : IGenericRepository<PrintDevice, PrintDeviceId>
{
}
