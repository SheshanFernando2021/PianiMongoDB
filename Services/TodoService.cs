using MongoDB.Driver;

public class TodoService : ITodoService
{
    private readonly IMongoCollection<Todo> _todos;

    public TodoService(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(configuration["MongoDB:Database"]);
        _todos = database.GetCollection<Todo>(configuration["MongoDB:CollectionName"]);
    }

    //Create a Todo
    public async Task CreateTodo(Todo todo)
    {
        await _todos.InsertOneAsync(todo);
    }

    //Delete a Todo
    public async Task DeleteTodo(string id)
    {
        await _todos.DeleteOneAsync(x => x.Id == id);
    }

    //Get all todos
    public async Task<List<Todo>> GetAllTodoAsync()
    {
        return await _todos.Find(_ => true).ToListAsync();
    }

    //Get todo by Id
    public async Task<Todo> GetTodoById(string Id)
    {
        return await _todos.Find(todo => todo.Id == Id).FirstOrDefaultAsync();
    }

    //Update a Todo
    public async Task UpdateTodo(string id, Todo updatedTodo)
    {
        await _todos.ReplaceOneAsync(x => x.Id == id, updatedTodo);
    }
}