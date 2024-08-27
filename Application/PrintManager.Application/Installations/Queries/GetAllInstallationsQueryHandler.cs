using ErrorOr;
using MediatR;
using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Application.Employees.Common;
using PrintManager.Application.Employees.Queries;
using PrintManager.Application.Installations.Common;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Domain.InstallationAggregate;
using System.Linq;

namespace PrintManager.Application.Installations.Queries;

public class GetAllInstallationsQueryHandler
     : IRequestHandler<GetAllInstallationsQuery, ErrorOr<List<GetInstallationResult>>>
{
    public GetAllInstallationsQueryHandler()
    {

    }

    public async Task<ErrorOr<List<GetInstallationResult>>> Handle(
        GetAllInstallationsQuery request, 
        CancellationToken cancellationToken)
    {
        return Error.NotFound();
    }
}
