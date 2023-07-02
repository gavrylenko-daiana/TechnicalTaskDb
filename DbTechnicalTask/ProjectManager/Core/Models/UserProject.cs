namespace Core.Models;

public class UserProject : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
}