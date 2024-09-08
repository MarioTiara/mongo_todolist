using Core.Entities;
using Core.IRepositories;
using Infrastructure.Database;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(MongoDbContext context) : base(context)
    {
    }

    public async Task<Role> GetByNameAsync(string name)
    => await Collection.Find(r=>r.Name==name).FirstOrDefaultAsync();
}
