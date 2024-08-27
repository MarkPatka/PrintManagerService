namespace PrintManager.Contracts.Employees;

public record GetEmployeeResponse(
    string id,
    string name,
    string jobTitle);
