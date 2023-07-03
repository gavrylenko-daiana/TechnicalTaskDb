using Core.Enums;

namespace Core.Models;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
    public virtual List<UserProject> UserProjects { get; set; } = new List<UserProject>();
    // public virtual List<ProjectTask> AssignedTasks { get; set; } = new List<ProjectTask>();
}
    // public List<Project> Projects { get; set; } = new List<Project>();
