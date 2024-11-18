using Microsoft.EntityFrameworkCore;
using SystemManagementMovie.Common.DataAccess;

namespace SystemManagementMovie.Moduls.Content.Repository;

public class ContentRepository : IContentRepository
{
    private readonly DataContext _context;

    public ContentRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Entities.Content content)
    {
        await _context.Set<Entities.Content>().AddAsync(content);
    }

    public async Task<Entities.Content> GetByIdAsync(Guid id)
    {
        return await _context.Set<Entities.Content>().FindAsync(id);
    }

    public async Task DeleteAsync(Entities.Content content)
    {
        _context.Set<Entities.Content>().Remove(content);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}