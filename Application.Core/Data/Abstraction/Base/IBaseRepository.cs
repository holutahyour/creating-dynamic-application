namespace Application.Core.Data
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity, string partitionKeyValue);
        Task<bool> DeleteAsync(string id, string partitionKeyValue);
        Task<IList<T>> GetAllAsync();
        Task<T> GetDetailByIdAsync(string id, string partitionKeyValue);
        Task<T> UpdateAsync(T entity, string id, string partitionKeyValue);
    }
}