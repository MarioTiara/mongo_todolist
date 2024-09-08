namespace Core.IRepositories;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task AddAsync(T entity);
    Task<bool> UpdateAsync(string id, T entity);
    Task<bool> DeleteAsync(string id);
}