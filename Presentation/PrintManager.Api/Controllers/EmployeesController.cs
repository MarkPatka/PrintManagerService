using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Application.Departments.Queries;
using PrintManager.Application.Employees.Queries;
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
            new GetPrintingDevicesRequest(departmentId));

        return Ok(query);
    }
}
