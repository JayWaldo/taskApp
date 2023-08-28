namespace taskApp.Models;

public class Objective
{
  public Guid ObjetiveId { get; set; }
  public Guid TaskId { get; set; }
  public string Description { get; set; }
  public bool Done { get; set; } = false;
  public Priority Priority { get; set; }
}