using PrintManager.Domain.DepartmentAggregate;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;

namespace PrintManager.Application.Common.Interfaces.Persistence;

public interface IDepartmentRepository : IGenericRepository<Department, DepartmentId>
{
}
