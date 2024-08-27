using Microsoft.EntityFrameworkCore;
using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Domain.DepartmentAggregate.Entities;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Infrastructure.Persistence.DBContexts;


namespace PrintManager.Infrastructure.Persistence.Repositories;

public class PrintDeviceRepository 
    : GenericRepository<DepartmentPrintDevice, DepartmentPrintDeviceId>,
    IPrintDeviceRepository
{
    private readonly IDbContextFactory<PrintManagementDbContext> _dbContextFactory;

    public PrintDeviceRepository(IDbContextFactory<PrintManagementDbContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }
}
