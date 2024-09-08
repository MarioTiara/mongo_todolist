namespace Infrastructure.Repositories;


using System.Threading.Tasks;
using Core.Entities;
using Core.IRepositories;
using Infrastructure.Database;
using MongoDB.Driver;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(MongoDbContext context) : base(context)
    {
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await Collection.Find(u=>u.Email==email).FirstOrDefaultAsync();
        return user;
    }

    public async Task<User> GetByUsernameAsync(string username)
    => await Collection.Find(u => u.Username == username).FirstOrDefaultAsync();
}
