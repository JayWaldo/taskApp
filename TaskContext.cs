using Microsoft.EntityFrameworkCore;
using taskApp.Models;
using Task = taskApp.Models.Task;

namespace taskApp;

public class TaskContext: DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Task> Tasks { get; set; }
  public DbSet<Goal> Objectives { get; set; }

  public TaskContext(DbContextOptions<TaskContext> options) :base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Category> categoryInit =  new List<Category>();
    categoryInit.Add(new Category()
    { 
      CategoryId = Guid.Parse("b1015608-7eae-4273-98a4-f244270062ab"), 
      Name = "SelfCare",
      Importance = 20
    });
    categoryInit.Add(new Category()
    { 
      CategoryId = Guid.Parse("b1015608-7eae-4273-98a4-f24427006210"), 
      Name = "Home",
      Importance = 15
    });

    modelBuilder.Entity<Category>(category =>
    {
      category.ToTable("Category");
      category.HasKey(p => p.CategoryId);
      category.Property(p => p.Name).IsRequired().HasMaxLength(150);
      category.Property(p=> p.Description).IsRequired(false);
      category.Property(p => p.Importance);
      category.HasData(categoryInit);
    });

    List<Task> taskInit = new List<Task>();
    taskInit.Add(new Task()
    {
      TaskId = Guid.Parse("b1015608-7eae-4273-98a4-f24427006211"),
      CategoryId = Guid.Parse("b1015608-7eae-4273-98a4-f244270062ab"),
      TaskPriority = Priority.Medium,
      Title = "Sleep 8 hrs",
      StartDate = DateTime.Now
    });
    taskInit.Add(new Task()
    {
      TaskId = Guid.Parse("b1015608-7eae-4273-98a4-f24427006212"),
      CategoryId = Guid.Parse("b1015608-7eae-4273-98a4-f24427006210"),
      TaskPriority = Priority.Medium,
      Title = "Wash the dishes",
      StartDate = DateTime.Now
    });

    modelBuilder.Entity<Task>(task =>
    {
      task.ToTable("Task");
      task.HasKey(p => p.TaskId);
      task.HasOne(p => p.Category).WithMany( p => p.Tasks).HasForeignKey( p => p.CategoryId);
      task.Property(p => p.Title).IsRequired().HasMaxLength(100);
      task.Property(p => p.Description).IsRequired(false).HasMaxLength(250);
      task.Property(p => p.TaskPriority).IsRequired();
      task.Property(p => p.StartDate);
      task.Property(p => p.EndDate);
      task.Ignore(p => p.Summary);
      task.HasData(taskInit);
    });
    modelBuilder.Entity<Goal>(goal => 
    {
      goal.ToTable("Goal");
      goal.HasKey(p => p.GoalId);
      goal.HasOne(p => p.Task).WithMany(p => p.Goals).HasForeignKey(p => p.TaskId);
      goal.Property(p => p.Description).IsRequired().HasMaxLength(150);
      goal.Property(p => p.Done);
      goal.Property(p => p.Priority);
    });
  }
}