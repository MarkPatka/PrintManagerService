namespace PrintManager.Contracts.PrintDevices;

public record GetPrintingDeviceResponse(
    Guid id,
    string innerName,
    string originalName,
    int serialNumber,
    int isDefault,
    string connectionType,
    List<string>? macs);
