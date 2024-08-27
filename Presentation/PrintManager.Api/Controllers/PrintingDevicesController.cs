using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Application.Departments.Queries;
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
            new GetPrintingDevicesRequest(departmentId, connectionType));

        return Ok(query);
    }
}
