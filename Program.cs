using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taskApp;
var builder = WebApplication.CreateBuilder(args);
// Crear una Base de Datos en memoria y colocamos un nombre en los " "
//builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TaskDb"));
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("TaskCx"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConexion", async ([FromServices] TaskContext dbContext) => 
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tasks", async ([FromServices] TaskContext dbContext) =>
{
  return Results.Ok(dbContext.Tasks.Include(p => p.Category).Where(p => p.TaskPriority == taskApp.Models.Priority.Medium));
});

app.MapPost("/api/tasks", async ([FromServices] TaskContext dbContext, [FromBody] taskApp.Models.Task task) =>
{
  task.TaskId = Guid.NewGuid();
  task.StartDate = DateTime.Now;
  await dbContext.AddAsync(task);
  //await dbContext.Tasks.AddAsync(task);

  await dbContext.SaveChangesAsync();

  return Results.Ok();
});

app.MapPut("/api/tasks/{id}", async ([FromServices] TaskContext dbContext, [FromBody] taskApp.Models.Task task, [FromRoute] Guid id) =>
{
  var currentTask = dbContext.Tasks.Find(id);

  if(currentTask != null)
  {
    currentTask.CategoryId = task.CategoryId;
    currentTask.Title = task.Title;
    currentTask.TaskPriority = task.TaskPriority;
    currentTask.Description = task.Description;

    await dbContext.SaveChangesAsync();
    return Results.Ok();
  }
  return Results.NotFound();
});

app.MapDelete("/api/tasks/{id}", async ([FromServices] TaskContext dbContext, [FromRoute] Guid id) =>
{
  var currentTask = dbContext.Tasks.Find(id);

  if(currentTask != null)
  {
    dbContext.Remove(currentTask);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
  }

  return Results.NotFound();
});

app.Run();
