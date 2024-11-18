using MediatR;
using Microsoft.EntityFrameworkCore;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.DataAccess;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Moduls.UserIdentity.Commands.CommandRequest;
using SystemManagementMovie.Moduls.UserIdentity.Entities;
using SystemManagementMovie.Moduls.UserIdentity.Mapper;

namespace SystemManagementMovie.Moduls.UserIdentity.Commands.CommandHandler;

public class UpdateUserHandler(AppCommandDbContext context) : IRequestHandler<UpdateUserRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        User? existingBO = await context.Users
            .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

        if(existingBO is null)
            return BaseResult.Failure(Error.NotFound());

        bool conflict = await context.Users.AnyAsync(x
            => x.Id != request.Id && x.FullName.ToLower() ==
            request.UserBaseInfo.FullName.ToLower(), cancellationToken);

        if(conflict)
            return BaseResult.Failure(Error.Conflict());

        existingBO.ToUpdateUser(request);
        int res = await context.SaveChangesAsync(cancellationToken);

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved"))
            : BaseResult.Success();
    }
}