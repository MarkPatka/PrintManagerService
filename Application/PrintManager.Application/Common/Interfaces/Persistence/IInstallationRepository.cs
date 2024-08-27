using PrintManager.Domain.InstallationAggregate;
using PrintManager.Domain.InstallationAggregate.ValueObjects;

namespace PrintManager.Application.Common.Interfaces.Persistence;

public interface IInstallationRepository 
    : IGenericRepository<Installation, InstallationId>
{
}
