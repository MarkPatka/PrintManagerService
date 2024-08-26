using MediatR;
using ErrorOr;
using PrintManager.Application.PrintDevices.Common;

namespace PrintManager.Application.Departments.Queries;

public record GetAllDevicesQuery() : IRequest<ErrorOr<List<GetAllDevicesResult>>>;
