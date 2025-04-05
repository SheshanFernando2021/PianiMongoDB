public interface ITodoService
{
    Task<List<Todo>> GetAllTodoAsync();
    Task<Todo> GetTodoById(string Id);
    Task CreateTodo(Todo todo);
    Task UpdateTodo(string id, Todo updatedTodo);
    Task DeleteTodo(string id);
}