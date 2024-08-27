namespace PrintManager.Application.Installations.Common;

public record GetInstallationResult(
    string departmentId,
    string name,
    GetInstalledDeviceResult installedDevice);

public record GetInstalledDeviceResult(
    string innerName,
    string originalName,
    int serialNumber,
    int isDefault,
    string connectionType);
