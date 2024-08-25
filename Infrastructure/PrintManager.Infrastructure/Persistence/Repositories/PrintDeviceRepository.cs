using Microsoft.EntityFrameworkCore;
using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Infrastructure.Persistence.DBContexts;
using PrintManager.Domain.PrintDeviceAggregate;
using PrintManager.Domain.PrintDeviceAggregate.ValueObjects;

namespace PrintManager.Infrastructure.Persistence.Repositories;

public class PrintDeviceRepository 
    : GenericRepository<PrintDevice, PrintDeviceId>,
    IPrintDeviceRepository
{
    private readonly IDbContextFactory<PrintManagementDbContext> _dbContextFactory;

    public PrintDeviceRepository(IDbContextFactory<PrintManagementDbContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }
}
