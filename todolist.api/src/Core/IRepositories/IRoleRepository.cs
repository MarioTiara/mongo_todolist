using Core.Entities;

namespace Core.IRepositories;

public interface IRoleRepository: IRepository<Role>
{
    Task<Role> GetByNameAsync(string name);
}