using Mapster;
using PrintManager.Application.Departments.Queries;
using PrintManager.Application.Installations.Commands;
using PrintManager.Application.Installations.Common;
using PrintManager.Application.Installations.Queries;
using PrintManager.Application.PrintDevices.Common;
using PrintManager.Contracts.Installations;
using PrintManager.Contracts.PrintDevices;

namespace PrintManager.Api.Common.Mapping;

public class InstallationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllInstallationsRequest, GetAllInstallationsQuery>()
            .Map(dest => dest, src => src);
        config.NewConfig<GetInstallationRequest, GetInstallationQuery>()
            .Map(dest => dest, src => src);
        config.NewConfig<GetInstallationResult, GetInstallationResponse>()
            .Map(dest => dest, src => src);
        config.NewConfig<GetInstalledDeviceResult, GetInstalledDeviceResponse>()
            .Map(dest => dest, src => src);



        config.NewConfig<InstallDeviceRequest, InstallDeviceCommand>()
            .Map(dest => dest, src => src);
        config.NewConfig<InstallDeviceResult, InstallDeviceResponse>()
            .Map(dest => dest, src => src);


        config.NewConfig<DeleteInstallationRequest, DeleteInstallationCommand>()
            .Map(dest => dest, src => src);
        config.NewConfig<DeleteInstallationResult, DeleteInstallationResponse>()
            .Map(dest => dest, src => src);
    }
}
