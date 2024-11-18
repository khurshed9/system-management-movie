using System.Linq.Expressions;

namespace SystemManagementMovie.Common.Base.Repository;

public interface IGenericFindRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
}