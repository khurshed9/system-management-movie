using MediatR;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Common.UOW;
using SystemManagementMovie.Moduls.Content.Commands.CommandRequest;
using SystemManagementMovie.Moduls.Content.Mapper;

namespace SystemManagementMovie.Moduls.Content.Commands.CommandHandler.Admin;

public class CreateAdminHandler(IUnitOfWork<Entities.Admin> unitOfWork) : IRequestHandler<CreateAdminRequest, BaseResult>
{
    public async Task<BaseResult> Handle(CreateAdminRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<Entities.Admin> repository = unitOfWork.AdminAddRepository;
        IGenericFindRepository<Entities.Admin> findRepository = unitOfWork.AdminFindRepository;
                                                                                                                            
        bool conflict =
            (await findRepository.FindAsync(x => x.FullName.ToLower().Contains(request.AdminBaseInfo.FullName))).Any();

        if(conflict)
            return BaseResult.Failure(Error.AlreadyExists());

        await repository.AddAsync(request.ToAdmin());

        int res = await unitOfWork.Complete();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
        
    }
}