using PrintManager.Domain.PrintSessionAggregate.Entities;
using PrintManager.Domain.PrintSessionAggregate.ValueObjects;

namespace PrintManager.Application.Common.Interfaces.Persistence;

public interface IEmployeeRepository : IGenericRepository<Employee, EmployeeId>
{
}
