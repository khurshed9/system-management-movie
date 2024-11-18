using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SystemManagementMovie.Common.DataAccess;

namespace SystemManagementMovie.Common.Base.Repository;


public class GenericFindRepository<T>(AppQueryDbContext context) : IGenericFindRepository<T> where T : BaseEntity
{
    public async Task<T?> GetByIdAsync(int id)
    {
        return await context.Set<T>().Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
    {
        return await context.Set<T>().Where(x => !x.IsDeleted).Where(expression).ToListAsync();
    }
}