using Microsoft.EntityFrameworkCore;
using taskApp.Models;
using Task = taskApp.Models.Task;

namespace taskApp;

public class TaskContext: DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Task> Tasks { get; set; }
  public DbSet<Goal> Goals { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<UserTask> UserTasks { get; set; }

  public TaskContext(DbContextOptions<TaskContext> options) :base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Category> categoriesInit = new List<Category>();
    categoriesInit.Add(new Category() {CategoryId = Guid.Parse("9472d245-d46c-4b17-9f4a-f3870d674b72"), Name = "Home", Description = "Home task of daily basis", Importance = 15});
    categoriesInit.Add(new Category() {CategoryId = Guid.Parse("ed937cce-c11d-4aa1-a503-49bd5075ad23"), Name = "SelfCare", Description = "SelfCare task to improve yourself", Importance = 20});
    modelBuilder.Entity<Category>(category =>
    {
      category.ToTable("Category");
      category.HasKey(p => p.CategoryId);
      category.Property(p => p.Name).IsRequired().HasMaxLength(150);
      category.Property(p=> p.Description).IsRequired(false);
      category.Property(p => p.Importance);
      category.HasData(categoriesInit);
    });

    List<Task> tasksInit = new List<Task>();
    tasksInit.Add(new Task() {TaskId = Guid.Parse("87be8727-3d2e-45e7-b686-0049301f1ba9"), CategoryId = Guid.Parse("9472d245-d46c-4b17-9f4a-f3870d674b72"), Title = "Wash the Dishes", TaskPriority = Priority.Medium, StartDate = DateTime.Now});
    tasksInit.Add(new Task() {TaskId = Guid.Parse("a26e416a-7a3c-4caf-8613-45df7daf0908"), CategoryId = Guid.Parse("ed937cce-c11d-4aa1-a503-49bd5075ad23"), Title = "Meditate", TaskPriority = Priority.Medium, StartDate = DateTime.Now});

    modelBuilder.Entity<Task>(task =>
    {
      task.ToTable("Task");
      task.HasKey(p => p.TaskId);
      task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey( p => p.CategoryId).OnDelete(DeleteBehavior.NoAction);
      task.Property(p => p.Title).IsRequired().HasMaxLength(100);
      task.Property(p => p.Description).IsRequired(false).HasMaxLength(250);
      task.Property(p => p.TaskPriority).IsRequired();
      task.Property(p => p.StartDate);
      task.Property(p => p.EndDate);
      task.Ignore(p => p.Summary);
      task.HasData(tasksInit);
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

    modelBuilder.Entity<User>(user =>
    {
      user.ToTable("User");
      user.HasKey(p => p.UserId);
      user.Property(p => p.FirstName).IsRequired();
      user.Property(p => p.LastName).IsRequired();
      user.Property(p => p.Email).IsRequired();
      user.Property(p => p.Password).IsRequired();
    });

    modelBuilder.Entity<UserTask>().HasKey(ut => new { ut.UserId, ut.CategoryId});
    modelBuilder.Entity<UserTask>()
      .HasOne(ut => ut.User)
      .WithMany(u => u.UserTasks)
      .HasForeignKey(ut => ut.UserId).OnDelete(DeleteBehavior.NoAction);
    
    modelBuilder.Entity<UserTask>()
      .HasOne(ut => ut.Categories)
      .WithMany(t => t.UserTasks)
      .HasForeignKey(ut => ut.CategoryId).OnDelete(DeleteBehavior.NoAction);
  }
}