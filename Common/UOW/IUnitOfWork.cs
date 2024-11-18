using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Moduls.Content.Entities;
using SystemManagementMovie.Moduls.UserIdentity.Entities;

namespace SystemManagementMovie.Common.UOW;

public  interface IUnitOfWork<T> : IDisposable,IAsyncDisposable where T : BaseEntity
{
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
    
    Task<int> Complete();
}