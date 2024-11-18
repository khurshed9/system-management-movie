using MediatR;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Moduls.UserIdentity.Entities;
using SystemManagementMovie.Moduls.UserIdentity.Filters;

namespace SystemManagementMovie.Moduls.UserIdentity.Queries.ViewModels;

public readonly record struct GetUserVm(
    int Id,
    UserBaseInfo UserBaseInfo);
    
    
public record GetUserVmRequest(UserFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<GetUserVm>>>>;