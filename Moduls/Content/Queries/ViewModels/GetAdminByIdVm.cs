using MediatR;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Moduls.Content.Entities;

namespace SystemManagementMovie.Moduls.Content.Queries.ViewModels;

public readonly record struct GetAdminByIdVm(
    int Id,
    AdminBaseInfo AdminBaseInfo,
    string FileName);

public record GetAdminByIdVmRequest(int Id) : IRequest<Result<GetAdminByIdVm>>;