using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Application.Departments.Queries;
using PrintManager.Contracts.PrintDevices;

namespace PrintManager.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("devices")]
public class PrintingDevicesController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public PrintingDevicesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;       
    }

    [HttpGet("getall")]
    public async Task<IActionResult> ListDevices()
    {
        var query = _mapper.Map<GetAllDevicesQuery>(new GetPrintingDevicesRequest());
        return Ok(query);
    }


}
