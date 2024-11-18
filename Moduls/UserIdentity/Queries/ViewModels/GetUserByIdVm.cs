using MediatR;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Moduls.UserIdentity.Entities;

namespace SystemManagementMovie.Moduls.UserIdentity.Queries.ViewModels;

public readonly record struct GetUserByIdVm(
    int Id,
    UserBaseInfo UserBaseInfo);
    
    
public record GetUserByIdVmRequest(int Id) :   IRequest<Result<GetUserByIdVm>>;