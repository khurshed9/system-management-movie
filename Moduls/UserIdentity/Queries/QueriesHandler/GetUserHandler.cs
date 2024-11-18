using System.Linq.Expressions;
using MediatR;
using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Common.Extensions;
using SystemManagementMovie.Common.UOW;
using SystemManagementMovie.Moduls.UserIdentity.Entities;
using SystemManagementMovie.Moduls.UserIdentity.Mapper;
using SystemManagementMovie.Moduls.UserIdentity.Queries.ViewModels;

namespace SystemManagementMovie.Moduls.UserIdentity.Queries.QueriesHandler;

public class GetUserHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<GetUserVmRequest, Result<PagedResponse<IEnumerable<GetUserVm>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetUserVm>>>> Handle(GetUserVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<User> repository = unitOfWork.UserFindRepository;
        
        Expression<Func<User, bool>> filterExpression = user =>
            (request.Filter.HasPremium == null || user.HasPremium == request.Filter.HasPremium);

        IEnumerable<User> query = (await repository
            .FindAsync(filterExpression)).ToList();
        
        int totalRecords = query.Count();
        
        IEnumerable<GetUserVm> businessOwners = query.Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo()).ToList();
        
        PagedResponse<IEnumerable<GetUserVm>> response = PagedResponse<IEnumerable<GetUserVm>>.Create(request.Filter.PageNumber, request.Filter.PageSize,
            totalRecords, businessOwners);
        
        return Result<PagedResponse<IEnumerable<GetUserVm>>>.Success(response);
    }
}