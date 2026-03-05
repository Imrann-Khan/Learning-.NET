using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("todos")]
public class TodosController : ControllerBase
{
    private readonly List<string> todos = new List<string>
    {
        "1. first todo"
    };

    [HttpGet]
    public IActionResult GetTodos()
    {
        return Ok(todos);
    }

    [HttpPost("/create")]
    public IActionResult CreateTodo(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Results.BadRequest("Todo title cannot be empty");
        }
        todos.Add(title);
        return Created($"/todos/${todos.Count - 1}", title);
    }
}