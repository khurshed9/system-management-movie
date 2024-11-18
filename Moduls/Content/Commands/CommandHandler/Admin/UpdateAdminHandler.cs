using MediatR;
using Microsoft.EntityFrameworkCore;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.DataAccess;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Moduls.Content.Commands.CommandRequest;
using SystemManagementMovie.Moduls.Content.Mapper;

namespace SystemManagementMovie.Moduls.Content.Commands.CommandHandler.Admin;

public class UpdateAdminHandler(AppCommandDbContext context) : IRequestHandler<UpdateAdminRequest, BaseResult>
{
    public async Task<BaseResult> Handle(UpdateAdminRequest request, CancellationToken cancellationToken)
    {
        Entities.Admin? existingBO = await context.Admins
            .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

        if(existingBO is null)
            return BaseResult.Failure(Error.NotFound());

        bool conflict = await context.Users.AnyAsync(x
            => x.Id != request.Id && x.FullName.ToLower() ==
            request.AdminBaseInfo.FullName.ToLower(), cancellationToken);

        if(conflict)
            return BaseResult.Failure(Error.Conflict());

        existingBO.ToUpdateAdmin(request);
        int res = await context.SaveChangesAsync(cancellationToken);

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved"))
            : BaseResult.Success();
    }
}