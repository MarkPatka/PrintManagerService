using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Application.Departments.Queries;
using PrintManager.Contracts.Departments;
using PrintManager.Contracts.PrintDevices;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;


namespace PrintManager.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("departments")]
public class DepartmentsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public DepartmentsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> ListDepartments()
    {
        var query = _mapper.Map<GetAllDepartmentsQuery>(
            new GetDepartmentsRequest());
        return Ok();
    }

}
