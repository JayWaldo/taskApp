using Microsoft.EntityFrameworkCore;
using taskApp.Models;

namespace taskApp;

public class TaskContext: DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Task> Tasks { get; set; }
  public DbSet<Objective> Objectives { get; set; }

  public TaskContext(DbContextOptions<TaskContext> options) :base(options) { }
}