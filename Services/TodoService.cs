using MongoDB.Driver;

public class TodoService
{
    private readonly IMongoCollection<Todo> _todos;

    public TodoService(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(configuration["MongoDB:Database"]);
        _todos = database.GetCollection<Todo>(configuration["MongoDB:CollectionName"]);
    }
}