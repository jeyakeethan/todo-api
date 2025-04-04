using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly TodoService _toDoService;

    public TodoController(TodoService toDoService)
    {
        _toDoService = toDoService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var todos = _toDoService.GetRecentTodos();
        return Ok(todos);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Todo todo)
    {
        if (todo == null)
        {
            return BadRequest("Todo is required.");
        }

        _toDoService.AddTodo(todo);
        return CreatedAtAction(nameof(Get), new { title = todo.Title }, todo);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _toDoService.RemoveTodo(id);
        if (result)
        {
            return NoContent(); // successfully deleted
        }
        return NotFound(); // todo not found
    }
}
