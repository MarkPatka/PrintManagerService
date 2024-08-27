using Mapster;
using PrintManager.Application.Employees.Common;
using PrintManager.Application.Employees.Queries;
using PrintManager.Contracts.Employees;

namespace PrintManager.Api.Common.Mapping;

public class EmployeeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetEmployeesRequest, GetAllEmployeesQuery>()
            .Map(dest => dest, src => src);

        config.NewConfig<GetAllEmployeesResult, GetEmployeeResponse>()
            .Map(dest => dest, src => src);
    }
}
