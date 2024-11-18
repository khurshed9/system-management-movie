using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Moduls.Content.Commands.CommandRequest;
using SystemManagementMovie.Moduls.UserIdentity.Controllers;

namespace SystemManagementMovie.Moduls.Content.Controllers.CommandController;

[Route("api/admins")]
public class AdminCommandController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAdminRequest entity)
    {
        BaseResult result = await mediator.Send(entity);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdminRequest entity)
    {
        BaseResult result = await mediator.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await mediator.Send(new DeleteAdminRequest(id));
        return result.ToActionResult();
    }
}