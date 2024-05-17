namespace Application.Core.Data;

public abstract class BaseRepository<T> : IBaseRepository<T>
    where T : class
{
    private readonly CosmosDB<T> _cosmosDB;

    public BaseRepository()
    {
        _cosmosDB = new CosmosDB<T>();
    }

    public async Task<T> CreateAsync(T entity, string partitionKeyValue)
    {
        var response = await _cosmosDB.AddAsync(entity, partitionKeyValue);

        return response;
    }

    public async Task<IList<T>> GetAllAsync()
    {
        var responses = await _cosmosDB.GetAllAsync();

        return responses;
    }

    public async Task<T> GetDetailByIdAsync(string id, string partitionKeyValue)
    {
        var response = await _cosmosDB.GetDetailsByIdAsync(id, partitionKeyValue);

        return response;
    }

    public async Task<T> UpdateAsync(T entity, string id, string partitionKeyValue)
    {
        var responses = await _cosmosDB.UpdateAsync(entity, id, partitionKeyValue);

        return responses;
    }

    public async Task<bool> DeleteAsync(string id, string partitionKeyValue)
    {
        var response = await _cosmosDB.DeleteAsync(id, partitionKeyValue);

        return response;
    }
}
