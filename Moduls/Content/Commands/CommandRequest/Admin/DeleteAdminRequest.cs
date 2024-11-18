using MediatR;
using SystemManagementMovie.Common.Base;

namespace SystemManagementMovie.Moduls.Content.Commands.CommandRequest;

public readonly record struct DeleteAdminRequest(int Id) : IRequest<BaseResult>;
