using ErrorOr;
using MediatR;
using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Application.Departments.Common;

namespace PrintManager.Application.Departments.Queries;

public class GetAllDepartmentsQueryHandler 
    : IRequestHandler<GetAllDepartmentsQuery, ErrorOr<List<GetAllDepartmentsResult>>>
{
    private readonly IDepartmentRepository _departments;

    public GetAllDepartmentsQueryHandler(IDepartmentRepository departments)
    {
        _departments = departments;
    }

    public async Task<ErrorOr<List<GetAllDepartmentsResult>>> Handle(
        GetAllDepartmentsQuery request, 
        CancellationToken cancellationToken)
    {
        var departments = await _departments.GetAllAsync();

        var result = departments.Select(deps =>
            new GetAllDepartmentsResult(
                id:  deps.Id.ToString(),
                name: deps.Name,
                address:  deps.Address,
                departmentDevices: deps.PrintDevices
                    .Select(devs => new GetAllDepartmentDevicesResult(
                        id: devs.Id.ToString()!,
                        innerName: devs.InnerName,
                        originalName: devs.OriginalName,
                        serialNumber: devs.SerialNumber,
                        isDefault: devs.IsDefaultDevice ? 1 : 0,
                        connectionType: devs.ConnectionType.Value,
                        macs: devs.MACs
                        .Select(m => BitConverter.ToString(m.MacAddress.GetAddressBytes()))
                        .ToList()))
                    .ToArray(),
                departmentEmployees: deps.Employees
                    .Select(emp => new GetAllDepartmentEmployeesResult(
                        emp.Id.ToString()!,
                        emp.Name,
                        emp.JobTitle))
                    .ToArray()))
            .ToList();

        return result;        
    }
}
