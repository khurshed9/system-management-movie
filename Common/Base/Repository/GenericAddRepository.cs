using SystemManagementMovie.Common.DataAccess;

namespace SystemManagementMovie.Common.Base.Repository;

public class GenericAddRepository<T>(AppCommandDbContext context): IGenericAddRepository<T> where T : BaseEntity
{
    public async Task AddAsync(T value)
    {
        await context.Set<T>().AddAsync(value);
    }

    public async Task AddRangeAsync(IEnumerable<T> values)
    {
        await context.Set<T>().AddRangeAsync(values);
    }
}