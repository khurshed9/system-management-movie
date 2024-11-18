using SystemManagementMovie.Common.DataAccess;

namespace SystemManagementMovie.Common.Base.Repository;

public class GenericUpdateRepository<T>(AppQueryDbContext context) : IGenericUpdateRepository<T> where T : BaseEntity
{
    public async Task UpdateAsync(T value)
    { 
        context.Set<T>().Update(value);
    }

    public async Task UpdateRangeAsync(IEnumerable<T> values)
    {
        context.Set<T>().UpdateRange(values);
    }
}