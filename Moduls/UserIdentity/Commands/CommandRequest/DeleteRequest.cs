using MediatR;
using SystemManagementMovie.Common.Base;

namespace SystemManagementMovie.Moduls.UserIdentity.Commands.CommandRequest;


public readonly record struct DeleteUserRequest(int Id) : IRequest<BaseResult>;