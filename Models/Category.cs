
namespace taskApp.Models;

public class Category
{
  public Guid CategoryId { get; set; }
  public Guid TaskId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public int Importance { get; set; }
  public virtual ICollection<Task> Tasks { get; set; }
  public virtual IList<UserTask> UserTasks { get; set; }
}