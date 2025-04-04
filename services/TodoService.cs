using System.Collections.Generic;
using System.Linq;

public class TodoService
{
    private readonly TodoDbContext _context;

    public TodoService(TodoDbContext context)
    {
        _context = context;
    }

    // Get most recent 5 todos
    public IEnumerable<Todo> GetRecentTodos()
    {
        return _context.Todos.OrderByDescending(todo => todo.Id).Take(5).ToList();
    }

    // Add a new todo
    public void AddTodo(Todo todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    // Remove a todo
    public bool RemoveTodo(int id)
    {
        var todoToRemove = _context.Todos.Find(id);
        if (todoToRemove != null)
        {
            _context.Todos.Remove(todoToRemove);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}
