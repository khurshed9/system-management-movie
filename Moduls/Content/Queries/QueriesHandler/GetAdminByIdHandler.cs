using MediatR;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Common.UOW;
using SystemManagementMovie.Moduls.Content.Entities;
using SystemManagementMovie.Moduls.Content.Mapper;
using SystemManagementMovie.Moduls.Content.Queries.ViewModels;

namespace SystemManagementMovie.Moduls.Content.Queries.QueriesHandler;

public class GetAdminByIdHandler(IUnitOfWork<Admin> _unitOfWork) : IRequestHandler<GetAdminByIdVmRequest, Result<GetAdminByIdVm>>
{
    public async Task<Result<GetAdminByIdVm>> Handle(GetAdminByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Admin> repository = _unitOfWork.AdminFindRepository;
        Admin? admin = await repository.GetByIdAsync(request.Id);
        GetAdminByIdVm viewModel = admin.ToReadByIdInfo();

        return Result<GetAdminByIdVm>.Success(viewModel);
    }
}
