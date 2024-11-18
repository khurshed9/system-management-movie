using MediatR;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Common.UOW;
using SystemManagementMovie.Moduls.UserIdentity.Commands.CommandRequest;
using SystemManagementMovie.Moduls.UserIdentity.Entities;

namespace SystemManagementMovie.Moduls.UserIdentity.Commands.CommandHandler;

public class DeleteUserHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<DeleteUserRequest, BaseResult>
{
    public async Task<BaseResult> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<User> repository = unitOfWork.UserDeleteRepository;
        IGenericFindRepository<User> findRepository = unitOfWork.UserFindRepository;

        User? user = await findRepository.GetByIdAsync(request.Id);
        if(user is null)
            return BaseResult.Failure(Error.NotFound());

        await repository.DeleteAsync(user);
        int res = await unitOfWork.Complete();
        
        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}