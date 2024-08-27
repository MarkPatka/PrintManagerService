using Microsoft.EntityFrameworkCore;
using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Domain.InstallationAggregate;
using PrintManager.Domain.InstallationAggregate.ValueObjects;
using PrintManager.Infrastructure.Persistence.DBContexts;

namespace PrintManager.Infrastructure.Persistence.Repositories;

public class InstallationRepository :
    GenericRepository<Installation, InstallationId>,
    IInstallationRepository
{
    private readonly IDbContextFactory<PrintManagementDbContext> _dbContextFactory;

    public InstallationRepository(IDbContextFactory<PrintManagementDbContext> dbContextFactory) 
        : base(dbContextFactory.CreateDbContext())
    {
    }
}
