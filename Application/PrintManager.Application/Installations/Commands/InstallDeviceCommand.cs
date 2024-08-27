using ErrorOr;
using MediatR;
using PrintManager.Application.Installations.Common;

namespace PrintManager.Application.Installations.Commands;

public record InstallDeviceCommand(
    string name,
    string printDeviceId,
    bool isDefaultDevice,
    int? serialNumber = null) 
    : IRequest<ErrorOr<InstallDeviceResult>>;
