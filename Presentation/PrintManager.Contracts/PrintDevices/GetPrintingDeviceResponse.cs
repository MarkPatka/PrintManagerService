namespace PrintManager.Contracts.PrintDevices;

public record GetPrintingDeviceResponse(
    Guid id,
    string name,
    int typecode,
    List<string>? macs);
