using ErrorOr;
using MediatR;
using PrintManager.Application.Installations.Common;

namespace PrintManager.Application.Installations.Commands;

public record DeleteInstallationCommand(string id)
    : IRequest<ErrorOr<DeleteInstallationResult>>;
