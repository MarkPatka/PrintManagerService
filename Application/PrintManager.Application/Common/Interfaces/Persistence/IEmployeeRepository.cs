using PrintManager.Domain.DepartmentAggregate.Entities;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;

namespace PrintManager.Application.Common.Interfaces.Persistence;

public interface IEmployeeRepository : IGenericRepository<Employee, EmployeeId>
{
}
