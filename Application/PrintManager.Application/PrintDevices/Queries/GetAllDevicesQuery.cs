using MediatR;
using ErrorOr;
using PrintManager.Application.PrintDevices.Common;

namespace PrintManager.Application.Departments.Queries;

public record GetAllDevicesQuery(
    string departmentId,
    int? connectionTypeCode = null) 
    : IRequest<ErrorOr<List<GetAllDevicesResult>>>;
