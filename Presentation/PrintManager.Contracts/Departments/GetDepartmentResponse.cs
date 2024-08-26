namespace PrintManager.Contracts.Departments;

public record GetDepartmentResponse(
    Guid id,
    string name,
    string address);
