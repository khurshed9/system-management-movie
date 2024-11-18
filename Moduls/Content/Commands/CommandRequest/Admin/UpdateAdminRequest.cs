using MediatR;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Moduls.Content.Entities;

namespace SystemManagementMovie.Moduls.Content.Commands.CommandRequest;

public readonly record struct UpdateAdminRequest(
    int Id,
    AdminBaseInfo AdminBaseInfo,
    IFormFile? File) : IRequest<BaseResult>;
