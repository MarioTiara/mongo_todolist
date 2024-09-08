using Core.IRepositories;
using Infrastructure.Database;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : class
{
    private readonly IMongoCollection<T> _collection;
    public Repository(MongoDbContext context)
    {
        _collection = context.GetCollection<T>(typeof(T).Name);
    }

    protected IMongoCollection<T> Collection => _collection;
    public virtual async Task AddAsync(T entity)
    => await _collection.InsertOneAsync(entity);

    public virtual async Task<bool> DeleteAsync(string id)
    {
        var filters= Builders<T>.Filter.Eq("_id", id);
        var resullt= await _collection.DeleteOneAsync(filters);
        return resullt.DeletedCount>0;
    }

    public virtual async Task<List<T>> GetAllAsync()
    => await _collection.Find(_ => true).ToListAsync();
    

    public virtual async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("_id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public virtual async Task<bool> UpdateAsync(string id, T entity)
    {
        var filter = Builders<T>.Filter.Eq("_id", id);
        var result = await _collection.ReplaceOneAsync(filter, entity);
        return result.MatchedCount>0;
    }
}