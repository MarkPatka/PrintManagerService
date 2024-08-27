using ErrorOr;
using MediatR;
using PrintManager.Application.Departments.Common;
using PrintManager.Application.Employees.Common;

namespace PrintManager.Application.Employees.Queries;

public class GetAllEmployeesQueryHandler
    : IRequestHandler<GetAllEmployeesQuery, ErrorOr<List<GetAllEmployeesResult>>>
{
    public GetAllEmployeesQueryHandler()
    {
    }

    public Task<ErrorOr<List<GetAllEmployeesResult>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
