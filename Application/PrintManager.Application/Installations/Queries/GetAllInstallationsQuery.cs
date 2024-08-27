using ErrorOr;
using MediatR;
using PrintManager.Application.Installations.Common;

namespace PrintManager.Application.Installations.Queries;

public record GetAllInstallationsQuery()
    : IRequest<ErrorOr<List<GetInstallationResult>>>;
