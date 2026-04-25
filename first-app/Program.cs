// Step 1
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi(); //If add docs for open-api


//Step 2
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Step 3
app.Run();

