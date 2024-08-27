using Mapster;
using PrintManager.Application.Departments.Queries;
using PrintManager.Application.PrintDevices.Common;
using PrintManager.Contracts.PrintDevices;

namespace PrintManager.Api.Common.Mapping;

public class PrintDeviceMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetPrintingDevicesRequest, GetAllDevicesQuery>()
            .Map(dest => dest, src => src);

        config.NewConfig<GetAllDevicesResult, GetPrintingDeviceResponse>()
            .Map(dest => dest, src => src);
    }
}
