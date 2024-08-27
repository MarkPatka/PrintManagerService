namespace PrintManager.Contracts.Departments;

public record GetDepartmentsResponse(
    string id,
    string name,
    string address);
