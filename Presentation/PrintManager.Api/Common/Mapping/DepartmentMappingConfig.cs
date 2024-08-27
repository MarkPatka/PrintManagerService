using Mapster;
using PrintManager.Application.Departments.Common;
using PrintManager.Application.Departments.Queries;
using PrintManager.Contracts.Departments;

namespace PrintManager.Api.Common.Mapping;

public class DepartmentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetDepartmentsRequest, GetAllDepartmentsQuery>()
            .Map(dest => dest, src => src);

        config.NewConfig<GetAllDepartmentsResult, GetDepartmentsResponse>()
            .Map(dest => dest.id, src => src.id)
            .Map(dest => dest.name, src => src.name)
            .Map(dest => dest.address, src => src.address);
    }
}
