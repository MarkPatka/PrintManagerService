namespace PrintManager.Contracts.Installations;

public record GetInstallationResponse(
    string departmentId,
    string name,
    GetInstalledDeviceResponse installedDevice);

public record GetInstalledDeviceResponse(
    string innerName,
    string originalName,
    int serialNumber,
    int isDefault,
    string connectionType);
