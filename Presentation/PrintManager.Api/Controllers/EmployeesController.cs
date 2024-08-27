using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Application.Departments.Common;
using PrintManager.Application.Departments.Queries;
using PrintManager.Application.Employees.Common;
using PrintManager.Application.Employees.Queries;
using PrintManager.Contracts.Employees;
using PrintManager.Contracts.PrintDevices;

namespace PrintManager.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("departments/{departmentId}/employees")]
public class EmployeesController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public EmployeesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> ListEmployees(string departmentId)
    {
        var query = _mapper.Map<GetAllEmployeesQuery>(
            new GetEmployeesRequest(departmentId));

        ErrorOr<List<GetAllEmployeesResult>> employeesResult = await _sender.Send(query);

        if (employeesResult.IsError) 
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: employeesResult.FirstError.Description);
        }

        return employeesResult.Match(
            employeesResult => Ok(_mapper.Map<List<GetEmployeeResponse>>(employeesResult)),
            errors => Problem(errors));
    }
}
