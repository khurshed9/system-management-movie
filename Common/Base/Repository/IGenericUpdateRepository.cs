
namespace SystemManagementMovie.Common.Base.Repository;


public interface IGenericUpdateRepository<T> where T : BaseEntity
{
    Task UpdateAsync(T value);
    
    Task UpdateRangeAsync(IEnumerable<T> values);
}