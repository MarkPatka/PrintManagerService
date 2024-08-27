using System.Globalization;

namespace PrintManager.Application.Departments.Common;

public record GetAllDepartmentsResult(
    string id,
    string name,
    string address,
    GetAllDepartmentDevicesResult departmentDevices,
    GetAllDepartmentEmployeesResult departmentEmployees);

public record GetAllDepartmentEmployeesResult(
    string id,
    string name,
    string jobTitle);

public record GetAllDepartmentDevicesResult(
    string id,
    string innerName,
    string originalName,
    int serialNumber,
    int isDefault,
    string connectionType,
    List<string>? macs);
