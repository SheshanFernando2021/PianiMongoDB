using Microsoft.AspNetCore.Mvc;

namespace PianiMongoDB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todos = await _todoService.GetAllTodoAsync();
        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var todo = await _todoService.GetTodoById(id);
        return todo == null ? NotFound(new { Message = "No tasks found" }) : Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> NewTask([FromBody] Todo todo)
    {
        todo.CreatedAt = DateTime.Now;
        await _todoService.CreateTodo(todo);
        return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(string id, [FromBody] Todo updatedTodo)
    {
        var ExistingTodo = await _todoService.GetTodoById(id);
        if (ExistingTodo == null)
        {
            return NotFound(new { Message = "No task found" });
        }
        updatedTodo.Id = id;
        await _todoService.UpdateTodo(id, updatedTodo);
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteTask(string Id)
    {
        var ExistingTodo = await _todoService.GetTodoById(Id);
        if (ExistingTodo == null)
        {
            return NotFound(new { Message = "No task found" });
        }
        await _todoService.DeleteTodo(Id);
        return NoContent();
    }
}
