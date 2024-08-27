using ErrorOr;
using MediatR;
using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Application.Employees.Common;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;

namespace PrintManager.Application.Employees.Queries;

public class GetAllEmployeesQueryHandler
    : IRequestHandler<GetAllEmployeesQuery, ErrorOr<List<GetAllEmployeesResult>>>
{
    private readonly IDepartmentRepository _department;

    public GetAllEmployeesQueryHandler(IDepartmentRepository department)
    {
        _department = department;
    }

    public async Task<ErrorOr<List<GetAllEmployeesResult>>> Handle(
        GetAllEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        var dept = await _department.GetByIdAsync(
            DepartmentId.CreateFrom(Guid.Parse(request.departmentId)));

        var result = dept.Employees.Select(e => 
            new GetAllEmployeesResult(
                id: e.Id.ToString(),
                name: e.Name,
                jobTitle: e.JobTitle))
            .ToList();

        return result;
    }
}
