using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taskApp.Models;

public class Task
{
  [Key]
  public Guid TaskId { get; set; }
  
  [ForeignKey("CategoryId")]
  public Guid CategoryId { get; set; }
  
  [Required]
  [MaxLength(100)]
  public string Title { get; set; }
  
  [Required]
  [MaxLength(250)]
  public string Description { get; set; }
  public Priority TaskPriority { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public virtual Category Category { get; set; }
  public List<Objective> Objectives { get; set; }
  
  [NotMapped]
  public string Summary { get; set; }
}

public enum Priority
{
  Low,
  Medium,
  High,
  Urgent
}