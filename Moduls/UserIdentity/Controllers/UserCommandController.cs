using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Moduls.UserIdentity.Commands.CommandRequest;

namespace SystemManagementMovie.Moduls.UserIdentity.Controllers;

[Route("api/users")]
public class UserCommandController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest entity)
    {
        BaseResult result = await mediator.Send(entity);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserRequest entity)
    {
        BaseResult result = await mediator.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await mediator.Send(new DeleteUserRequest(id));
        return result.ToActionResult();
    }
}