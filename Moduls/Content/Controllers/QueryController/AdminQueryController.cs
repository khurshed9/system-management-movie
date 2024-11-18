using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Moduls.Content.Filter;
using SystemManagementMovie.Moduls.Content.Queries.ViewModels;
using SystemManagementMovie.Moduls.UserIdentity.Controllers;
using SystemManagementMovie.Moduls.UserIdentity.Filters;
using SystemManagementMovie.Moduls.UserIdentity.Queries.ViewModels;

namespace SystemManagementMovie.Moduls.Content.Controllers.QueryController;


[Route("api/admins")]
public class AdminQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAdmins([FromQuery] AdminFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetAdminVm>>> response = await sender.Send(new GetAdminVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAdminById( int id)
    {
        Result<GetAdminByIdVm> response = await sender.Send(new GetAdminByIdVmRequest(id));
        return response.ToActionResult();
    }
}