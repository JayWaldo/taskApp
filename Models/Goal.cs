using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taskApp.Models;

public class Goal
{
  public Guid GoalId { get; set; }
  public Guid TaskId { get; set; }
  public virtual Task Task { get; set; }
  public string Description { get; set; }
  public bool Done { get; set; } = false;
  public Priority Priority { get; set; }
}