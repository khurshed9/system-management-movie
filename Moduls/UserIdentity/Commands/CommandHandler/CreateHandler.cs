using MediatR;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Common.UOW;
using SystemManagementMovie.Moduls.UserIdentity.Commands.CommandRequest;
using SystemManagementMovie.Moduls.UserIdentity.Entities;
using SystemManagementMovie.Moduls.UserIdentity.Mapper;

namespace SystemManagementMovie.Moduls.UserIdentity.Commands.CommandHandler;

public class CreateUserHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<CreateUserRequest, BaseResult>
{
    public async Task<BaseResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<User> repository = unitOfWork.UserAddRepository;
        IGenericFindRepository<User> findRepository = unitOfWork.UserFindRepository;
        
        bool conflict =
            (await findRepository.FindAsync(x => x.FullName.ToLower().Contains(request.UserBaseInfo.FullName))).Any();

        if(conflict)
            return BaseResult.Failure(Error.AlreadyExists());

        await repository.AddAsync(request.ToUser());

        int res = await unitOfWork.Complete();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}