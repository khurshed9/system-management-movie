using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Moduls.UserIdentity.Filters;
using SystemManagementMovie.Moduls.UserIdentity.Queries.ViewModels;

namespace SystemManagementMovie.Moduls.UserIdentity.Controllers;


[Route("api/users")]
public class UserQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] UserFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetUserVm>>> response = await sender.Send(new GetUserVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById( int id)
    {
        Result<GetUserByIdVm> response = await sender.Send(new GetUserByIdVmRequest(id));
        return response.ToActionResult();
    }
}