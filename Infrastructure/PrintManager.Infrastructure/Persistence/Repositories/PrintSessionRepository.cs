using Microsoft.EntityFrameworkCore;
using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Infrastructure.Persistence.DBContexts;
using PrintManager.Domain.PrintSessionAggregate;
using PrintManager.Domain.PrintSessionAggregate.ValueObjects;

namespace PrintManager.Infrastructure.Persistence.Repositories;

public class PrintSessionRepository 
    : GenericRepository<PrintSession, PrintSessionId>,
    IPrintSessionRepository
{
    private readonly IDbContextFactory<PrintManagementDbContext> _dbContextFactory;

    public PrintSessionRepository(IDbContextFactory<PrintManagementDbContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }
}
