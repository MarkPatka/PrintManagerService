namespace PrintManager.Contracts.Employees;

public record GetEmployeeResponse(
    Guid id,
    string name,
    string jobTitle);
