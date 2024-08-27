using PrintManager.Application.Common.Interfaces.Persistence;
using PrintManager.Application.Common.Interfaces.Services;

namespace PrintManager.Infrastructure.Services;

public class InstallationService : IInstallationService
{
    private readonly IInstallationRepository _installations;
    private readonly IPrintDeviceRepository _deviceRepository;

    public InstallationService(
        IInstallationRepository installations,
        IPrintDeviceRepository deviceRepository)
    {
        _installations = installations;
        _deviceRepository = deviceRepository;
    }

    public async Task InstallAsync()
    {
        await Task.CompletedTask;
    }
}
