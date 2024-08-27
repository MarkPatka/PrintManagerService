using ErrorOr;
using MediatR;
using PrintManager.Application.Installations.Common;

namespace PrintManager.Application.Installations.Queries;

public record GetInstallationQuery(string installationId)
    : IRequest<ErrorOr<GetInstallationResult>>;
