namespace Application.Core.Data;

public class CosmosDB<T> where T: class
{
    private readonly string CosmosDBAccountUri = "https://localhost:8081/";
    private readonly string CosmosDBAccountPrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

    private readonly Database _database;
    private readonly Container _container;

    private readonly string CosmosDbName = "DynamicApplication";
    private readonly string CosmosDbContainerName = $"{typeof(T).Name.ToLower()}s";

    public CosmosDB()
    {
        Initialize().Wait();
    }

    private Container ContainerClient()
    {
        CosmosClient cosmosDbClient = new(CosmosDBAccountUri, CosmosDBAccountPrimaryKey);
        Container containerClient = cosmosDbClient.GetContainer(CosmosDbName, CosmosDbContainerName);
        return containerClient;
    }

    public async Task Initialize()
    {
        CosmosClient cosmosDbClient = new(CosmosDBAccountUri, CosmosDBAccountPrimaryKey);
        Database database = cosmosDbClient.GetDatabase(CosmosDbName);

        await database.CreateContainerIfNotExistsAsync(CosmosDbContainerName, "/Code");
    }

    public async Task<T> AddAsync(T entity, string partitionKeyValue)
    {
        try
        {
            var container = ContainerClient();

            var response = await container.CreateItemAsync(entity, new PartitionKey(partitionKeyValue));
            return response.Resource;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<List<T>> GetAllAsync()
    {
        try
        {
            var container = ContainerClient();
            var sqlQuery = "SELECT * FROM c";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);
            FeedIterator<T> queryResultSetIterator = container.GetItemQueryIterator<T>(queryDefinition);
            List<T> employees = new List<T>();
            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<T> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (T employee in currentResultSet)
                {
                    employees.Add(employee);
                }
            }
            return employees;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<T> GetDetailsByIdAsync(string id, string partitionKey)
    {
        try
        {
            var container = ContainerClient();
            ItemResponse<T> response = await container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
            return response.Resource;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<T> UpdateAsync(T entity, string id, string partitionKey)
    {
        try
        {
            var container = ContainerClient();
            ItemResponse<T> res = await container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));

            //Get Existing Item
            var existingItem = entity;

            var updateRes = await container.ReplaceItemAsync(existingItem, id, new PartitionKey(partitionKey));

            return updateRes.Resource;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<bool> DeleteAsync(string Id, string partitionKey)
    {
        try
        {
            var container = ContainerClient();
            var response = await container.DeleteItemAsync<T>(Id, new PartitionKey(partitionKey));
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
