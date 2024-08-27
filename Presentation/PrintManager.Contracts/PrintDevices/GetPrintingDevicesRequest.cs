namespace PrintManager.Contracts.PrintDevices;

public record GetPrintingDevicesRequest(
    string departmentId, 
    int? connectionTypeCode = null);
