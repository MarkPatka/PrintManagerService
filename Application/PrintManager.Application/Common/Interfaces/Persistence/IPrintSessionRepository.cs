using PrintManager.Domain.PrintSessionAggregate;
using PrintManager.Domain.PrintSessionAggregate.ValueObjects;

namespace PrintManager.Application.Common.Interfaces.Persistence;

public interface IPrintSessionRepository : IGenericRepository<PrintSession, PrintSessionId>
{
}
