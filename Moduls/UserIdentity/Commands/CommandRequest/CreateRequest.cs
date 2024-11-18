using MediatR;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Moduls.UserIdentity.Entities;

namespace SystemManagementMovie.Moduls.UserIdentity.Commands.CommandRequest;

public readonly record struct CreateUserRequest(
    UserBaseInfo UserBaseInfo) : IRequest<BaseResult>;