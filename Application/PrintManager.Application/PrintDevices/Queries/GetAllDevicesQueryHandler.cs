using ErrorOr;
using MediatR;
using PrintManager.Application.PrintDevices.Common;

namespace PrintManager.Application.Departments.Queries;

public class GetAllDevicesQueryHandler
    : IRequestHandler<GetAllDevicesQuery, ErrorOr<List<GetAllDevicesResult>>>
{
    public GetAllDevicesQueryHandler()
    {
        
    }
    public Task<ErrorOr<List<GetAllDevicesResult>>> Handle(GetAllDevicesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
