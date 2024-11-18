
namespace SystemManagementMovie.Common.Base.Repository;

public interface IGenericDeleteRepository<T> where T : BaseEntity
{
    Task DeleteAsync(T value);

    Task DeleteAsync(IEnumerable<T> values);
}