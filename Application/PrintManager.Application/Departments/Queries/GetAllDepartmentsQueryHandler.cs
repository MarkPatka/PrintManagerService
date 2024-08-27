using ErrorOr;
using MediatR;
using PrintManager.Application.Departments.Common;

namespace PrintManager.Application.Departments.Queries;

public class GetAllDepartmentsQueryHandler 
    : IRequestHandler<GetAllDepartmentsQuery, ErrorOr<List<GetAllDepartmentsResult>>>
{
    public GetAllDepartmentsQueryHandler()
    {
    }

    public Task<ErrorOr<List<GetAllDepartmentsResult>>> Handle(
        GetAllDepartmentsQuery request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
