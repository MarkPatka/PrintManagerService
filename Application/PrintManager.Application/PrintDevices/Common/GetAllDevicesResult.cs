namespace PrintManager.Application.PrintDevices.Common;

public record GetAllDevicesResult(
    string id,
    string innerName,
    string originalName,
    int serialNumber,
    int isDefault,
    string connectionType,
    List<string>? macs);
