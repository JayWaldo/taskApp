using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taskApp.Models;

public class Objective
{
  [Key]
  public Guid ObjetiveId { get; set; }

  [ForeignKey("TaskId")]
  public Guid TaskId { get; set; }

  [Required]
  [MaxLength(150)]
  public string Description { get; set; }
  public bool Done { get; set; } = false;
  public Priority Priority { get; set; }
}