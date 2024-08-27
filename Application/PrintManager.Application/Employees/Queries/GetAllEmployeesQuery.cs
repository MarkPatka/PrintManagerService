using ErrorOr;
using MediatR;
using PrintManager.Application.Employees.Common;

namespace PrintManager.Application.Employees.Queries;

public record GetAllEmployeesQuery(string departmentId)
    : IRequest<ErrorOr<List<GetAllEmployeesResult>>>;
