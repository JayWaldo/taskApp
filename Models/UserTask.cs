
namespace taskApp.Models
{
    public class UserTask
    {
        public virtual Guid UserId { get; set; }
        public User User { get; set; }

        public virtual Guid CategoryId { get; set; }
        public Category Categories { get; set; }
    }
}