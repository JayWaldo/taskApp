using System.ComponentModel.DataAnnotations;

namespace taskApp.Models;

public class Category
{
  [Key]
  public Guid CategoryId { get; set; }

  [Required]
  [MaxLength(150)]
  public string Name { get; set; }
  public string Description { get; set; }
  public virtual List<Task> Tasks { get; set; }
}