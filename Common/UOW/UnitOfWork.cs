using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Common.DataAccess;
using SystemManagementMovie.Moduls.Content.Entities;
using SystemManagementMovie.Moduls.UserIdentity.Entities;

namespace SystemManagementMovie.Common.UOW;

public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
{
    private readonly AppCommandDbContext _appCommand;
    private readonly AppQueryDbContext _queryContext;
    

    public IGenericUpdateRepository<User> UserUpdateRepository { get; }
    public IGenericDeleteRepository<User> UserDeleteRepository { get; }
    public IGenericFindRepository<User> UserFindRepository { get; }
    public IGenericAddRepository<User> UserAddRepository { get; }
    
    
    public IGenericUpdateRepository<Admin> AdminUpdateRepository { get; }
    public IGenericDeleteRepository<Admin> AdminDeleteRepository { get; }
    public IGenericFindRepository<Admin> AdminFindRepository { get; }
    public IGenericAddRepository<Admin> AdminAddRepository { get; }
    
    
    public IGenericAddRepository<Content> ContentAddRepository { get; }
    public IGenericFindRepository<Content> ContentFindRepository { get; }


    public UnitOfWork(AppCommandDbContext appCommand,
        AppQueryDbContext queryContext,
        IGenericUpdateRepository<User> userUpdateRepository,
        IGenericDeleteRepository<User> userDeleteRepository,
        IGenericFindRepository<User> userFindRepository,
        IGenericAddRepository<User> userAddRepository,
        IGenericUpdateRepository<Admin> adminUpdateRepository,
        IGenericDeleteRepository<Admin> adminDeleteRepository,
        IGenericFindRepository<Admin> adminFindRepository,
        IGenericAddRepository<Admin> adminAddRepository,
        IGenericAddRepository<Content> contentAddRepository,
        IGenericFindRepository<Content> contentFindRepository)
    {
        _appCommand = appCommand;
        _queryContext = queryContext;
        
        UserUpdateRepository = userUpdateRepository;
        UserDeleteRepository = userDeleteRepository;
        UserFindRepository = userFindRepository;
        UserAddRepository = userAddRepository;
        
        AdminUpdateRepository = adminUpdateRepository;
        AdminDeleteRepository = adminDeleteRepository;
        AdminFindRepository = adminFindRepository;
        AdminAddRepository = adminAddRepository;
        
        ContentAddRepository = contentAddRepository;
        ContentFindRepository = contentFindRepository;
        
    }
    
    
    public async Task<int> Complete()
    {
        return await _appCommand.SaveChangesAsync();
    }
    
    
    public void Dispose()
    {
        _appCommand.Dispose();
        _queryContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _appCommand.DisposeAsync();
        await _queryContext.DisposeAsync();
    }
}