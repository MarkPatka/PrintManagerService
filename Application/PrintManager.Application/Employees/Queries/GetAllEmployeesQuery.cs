using ErrorOr;
using MediatR;
using PrintManager.Application.Employees.Common;
using PrintManager.Domain.DepartmentAggregate.Entities;

namespace PrintManager.Application.Employees.Queries;

public record GetAllEmployeesQuery()
    : IRequest<ErrorOr<List<GetAllEmployeesResult>>>
{
}
