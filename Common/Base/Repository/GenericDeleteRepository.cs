using SystemManagementMovie.Common.DataAccess;

namespace SystemManagementMovie.Common.Base.Repository;

public class GenericDeleteRepository<T>(AppCommandDbContext context) : IGenericDeleteRepository<T> where T : BaseEntity
{
    public async Task DeleteAsync(T value)
    {
        context.Set<T>().Remove(value);
    }

    public async Task DeleteAsync(IEnumerable<T> values)
    {
        context.Set<T>().RemoveRange(values);
    }
}