namespace SystemManagementMovie.Moduls.Content.Repository;

public interface IContentRepository
{
    Task AddAsync(Entities.Content content);
    Task<Entities.Content> GetByIdAsync(Guid id);
    Task DeleteAsync(Entities.Content content);
    Task SaveChangesAsync();
}