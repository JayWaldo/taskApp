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

app.Run();
