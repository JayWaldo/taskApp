namespace taskApp.Models;

public class taskApp
{
  public Guid TaskId { get; set; }
  public Guid CategoryId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public Priority TaskPriority { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public virtual Category Category { get; set; }
  public List<Objective> Objectives { get; set; }
}

public enum Priority
{
  Low,
  Medium,
  High,
  Urgent
}