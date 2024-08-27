using ErrorOr;
using MediatR;
using PrintManager.Application.Departments.Common;

namespace PrintManager.Application.Departments.Queries;

public record GetAllDepartmentsQuery() 
    : IRequest<ErrorOr<List<GetAllDepartmentsResult>>>;
