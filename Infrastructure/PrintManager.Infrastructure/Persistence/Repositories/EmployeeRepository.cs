using Microsoft.EntityFrameworkCore;
using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Domain.PrintSessionAggregate.Entities;
using PrintManager.Domain.PrintSessionAggregate.ValueObjects;
using PrintManager.Infrastructure.Persistence.DBContexts;

namespace PrintManager.Infrastructure.Persistence.Repositories;

public class EmployeeRepository
    : GenericRepository<Employee, EmployeeId>,
    IEmployeeRepository
{
    private readonly IDbContextFactory<PrintManagementDbContext> _dbContextFactory;

    public EmployeeRepository(IDbContextFactory<PrintManagementDbContext> dbContextFactory) 
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }
}
