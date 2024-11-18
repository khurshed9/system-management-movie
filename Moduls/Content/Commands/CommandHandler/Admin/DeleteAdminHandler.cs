using MediatR;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Common.UOW;
using SystemManagementMovie.Moduls.Content.Commands.CommandRequest;
using SystemManagementMovie.Moduls.UserIdentity.Entities;

namespace SystemManagementMovie.Moduls.Content.Commands.CommandHandler.Admin;

public class DeleteAdminHandler(IUnitOfWork<Entities.Admin> unitOfWork) : IRequestHandler<DeleteAdminRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteAdminRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<Entities.Admin> repository = unitOfWork.AdminDeleteRepository;
        IGenericFindRepository<Entities.Admin> findRepository = unitOfWork.AdminFindRepository;

        Entities.Admin? admin = await findRepository.GetByIdAsync(request.Id);
        if(admin is null)
            return BaseResult.Failure(Error.NotFound());

        await repository.DeleteAsync(admin);
        int res = await unitOfWork.Complete();
        
        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}