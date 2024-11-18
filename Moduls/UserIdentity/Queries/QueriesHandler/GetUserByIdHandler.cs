using MediatR;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Common.UOW;
using SystemManagementMovie.Moduls.UserIdentity.Entities;
using SystemManagementMovie.Moduls.UserIdentity.Mapper;
using SystemManagementMovie.Moduls.UserIdentity.Queries.ViewModels;

namespace SystemManagementMovie.Moduls.UserIdentity.Queries.QueriesHandler;

public class GetUserByIdHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<GetUserByIdVmRequest, Result<GetUserByIdVm>>
{
    public async Task<Result<GetUserByIdVm>> Handle(GetUserByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<User> repository = unitOfWork.UserFindRepository;
        User? user = await repository.GetByIdAsync(request.Id);
        GetUserByIdVm viewModel = user.ToReadByIdInfo();

        return Result<GetUserByIdVm>.Success(viewModel);
    }
}