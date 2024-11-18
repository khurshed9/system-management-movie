using System.Linq.Expressions;
using MediatR;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Common.UOW;
using SystemManagementMovie.Moduls.Content.Entities;
using SystemManagementMovie.Moduls.Content.Mapper;
using SystemManagementMovie.Moduls.Content.Queries.ViewModels;

namespace SystemManagementMovie.Moduls.Content.Queries.QueriesHandler;

public class GetAdminHandler(IUnitOfWork<Admin> _unitOfWork) : IRequestHandler<GetAdminVmRequest, Result<PagedResponse<IEnumerable<GetAdminVm>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<GetAdminVm>>>> Handle(GetAdminVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Admin> repository = _unitOfWork.AdminFindRepository;
        
        Expression<Func<Admin, bool>> filterExpression = admin =>
            (request.Filter.CountryName == null || admin.CountryName == request.Filter.CountryName);

        IEnumerable<Admin> query = (await repository
            .FindAsync(filterExpression)).ToList();

        int totalRecords = query.Count();

        IEnumerable<GetAdminVm> admins = query.Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo()).ToList();

        PagedResponse<IEnumerable<GetAdminVm>> response = PagedResponse<IEnumerable<GetAdminVm>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize,
            totalRecords, 
            admins);

        return Result<PagedResponse<IEnumerable<GetAdminVm>>>.Success(response);
    }
}
