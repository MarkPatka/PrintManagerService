using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Application.Departments.Common;
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

        ErrorOr<List<GetAllDepartmentsResult>> departments = await _sender.Send(query);

        if (departments.IsError)
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: departments.FirstError.Description);
        }

        return departments.Match(
            departments => Ok(_mapper.Map<List<GetDepartmentsResponse>>(departments)),
            errors => Problem(errors));
    }

}
