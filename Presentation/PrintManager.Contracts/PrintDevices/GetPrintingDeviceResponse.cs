namespace PrintManager.Contracts.PrintDevices;

public record GetPrintingDeviceResponse(
    string id,
    string innerName,
    string originalName,
    int serialNumber,
    int isDefault,
    string connectionType,
    List<string>? macs);
