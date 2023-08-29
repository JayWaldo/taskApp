
namespace taskApp.Models;

public class Task
{
  public Guid TaskId { get; set; }
  public Guid CategoryId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public Priority TaskPriority { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public virtual Category Category { get; set; }
  public virtual List<Goal> Goals { get; set; }
  public string Summary { get; set; }
}

public enum Priority
{
  Low,
  Medium,
  High,
  Urgent
}