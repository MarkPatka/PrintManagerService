using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Application.Departments.Common;
using PrintManager.Application.Departments.Queries;
using PrintManager.Application.Employees.Common;
using PrintManager.Application.Employees.Queries;
using PrintManager.Application.PrintDevices.Common;
using PrintManager.Contracts.Employees;
using PrintManager.Contracts.PrintDevices;

namespace PrintManager.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("departments/{departmentId}/devices")]
public class PrintingDevicesController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public PrintingDevicesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;       
    }

    [HttpGet("{connectionType}")]
    public async Task<IActionResult> ListDevices(string departmentId, int? connectionType = null)
    {
        var query = _mapper.Map<GetAllDevicesQuery>(
            new GetPrintingDevicesRequest(departmentId));

        ErrorOr<List<GetAllDevicesResult>> devicesResult = await _sender.Send(query);

        if (devicesResult.IsError)
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: devicesResult.FirstError.Description);
        }

        return devicesResult.Match(
            employeesResult => Ok(_mapper.Map<List<GetPrintingDeviceResponse>>(devicesResult)),
            errors => Problem(errors));
    }
}
