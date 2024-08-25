using Microsoft.EntityFrameworkCore;
using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Domain.DepartmentAggregate;
using PrintManager.Domain.DepartmentAggregate.ValueObjects;
using PrintManager.Infrastructure.Persistence.DBContexts;

namespace PrintManager.Infrastructure.Persistence.Repositories;

public class DepartmentRepository
    : GenericRepository<Department, DepartmentId>,
    IDepartmentRepository
{
    private readonly IDbContextFactory<PrintManagementDbContext> _dbContextFactory;

    public DepartmentRepository(IDbContextFactory<PrintManagementDbContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }
}
