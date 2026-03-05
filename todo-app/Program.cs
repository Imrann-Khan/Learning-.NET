using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddController();

var app = builder.Build();

// var todos = new List<string>
// {
//     "1. first todo"
// };

// app.MapGet("todos/", (HttpContext context) =>
// {
//     return Results.Ok(todos);
// });

// app.MapPost("/todo", (Todo todo) =>
// {
//     if(string.IsNullOrWhiteSpace(todo.Title))
//     {
//         return Results.BadRequest("Todo title cannot be empty");
//     }
//     todos.Add(todo.Title);
//     return Results.Created($"/todos/${todos.Count - 1}", todo.Title);
// });

app.MapControllers();

app.Run();

// class Todo
// {
//     public string Title {get; set;} = string.Empty;
// }