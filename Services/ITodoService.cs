public interface ITodoService
{
    Task<List<Todo>> GetAllTodoAsync();
    Task<Todo> GetTodoById();
    Task CreateTodo(Todo todo);
    Task UpdateTodo(string id, Todo updatedTodo);
    Task DeleteTodo(string id);
}