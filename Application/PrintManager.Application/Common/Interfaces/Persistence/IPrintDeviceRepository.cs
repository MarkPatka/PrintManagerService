using PrintManager.Domain.DepartmentAggregate.Entities;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;

namespace PrintManager.Application.Common.Interfaces.Persistence;

public interface IPrintDeviceRepository 
    : IGenericRepository<DepartmentPrintDevice, DepartmentPrintDeviceId>
{
}
