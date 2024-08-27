using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Application.Installations.Commands;
using PrintManager.Application.Installations.Common;
using PrintManager.Application.Installations.Queries;
using PrintManager.Contracts.Installations;
using PrintManager.Domain.InstallationAggregate.ValueObjects;

namespace PrintManager.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("departments/{departmentId}/installations")]
public class InstallationsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public InstallationsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> InstallDevice(InstallDeviceRequest request)
    {
        var command = _mapper.Map<InstallDeviceCommand>(request);

        ErrorOr<InstallDeviceResult> installationResult = await _sender.Send(command);

        return installationResult.Match(
            createRangeTaskResult => Ok(_mapper.Map<InstallDeviceResponse>(installationResult)),
            errors => Problem(errors));
    }
    [HttpGet]
    public async Task<IActionResult> GetInstallations()
    {
        var query = _mapper.Map<GetAllInstallationsQuery>(new GetAllInstallationsRequest());
        ErrorOr<List<GetInstallationResult>> installationResult = await _sender.Send(query);

        if (installationResult.IsError)
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: installationResult.FirstError.Description);
        }

        return installationResult.Match(
            installationResult => Ok(_mapper.Map<List<GetInstallationResponse>>(installationResult)),
            errors => Problem(errors));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetInstallation(string id)
    {
        var query = _mapper.Map<GetInstallationQuery>(new GetInstallationRequest(id));
        ErrorOr<GetInstallationResult> installationResult = await _sender.Send(query);

        if (installationResult.IsError)
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: installationResult.FirstError.Description);
        }

        return installationResult.Match(
            installationResult => Ok(_mapper.Map<GetInstallationResponse>(installationResult)),
            errors => Problem(errors));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInstallation(string id)
    {
        var query = _mapper.Map<DeleteInstallationCommand>(new DeleteInstallationRequest(id));
        ErrorOr<DeleteInstallationResult> deleteInstallationResult = await _sender.Send(query);

        if (deleteInstallationResult.IsError)
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: deleteInstallationResult.FirstError.Description);
        }

        return deleteInstallationResult.Match(
            deleteInstallationResult => Ok(_mapper.Map<DeleteInstallationResponse>(deleteInstallationResult)),
            errors => Problem(errors));
    }
}
