namespace PrintManager.Contracts.Installations;

public record InstallDeviceRequest(
    string name,
    string printDeviceId,
    bool isDefaultDevice,
    int? serialNumber = null);
