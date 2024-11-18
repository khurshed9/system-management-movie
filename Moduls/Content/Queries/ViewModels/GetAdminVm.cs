using MediatR;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Moduls.Content.Entities;
using SystemManagementMovie.Moduls.Content.Filter;

namespace SystemManagementMovie.Moduls.Content.Queries.ViewModels;

public readonly record struct GetAdminVm(
    int Id,
    AdminBaseInfo AdminBaseInfo,
    string FileName);
    
 
public record GetAdminVmRequest(AdminFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<GetAdminVm>>>>;
   