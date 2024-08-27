namespace PrintManager.Contracts.Departments;

public record GetDepartmentsResponse(
    Guid id,
    string name,
    string address);
