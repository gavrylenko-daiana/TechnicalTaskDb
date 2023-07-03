using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;

namespace Core.Models;

public class ProjectTask : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; } = null!;
    public DateTime DueDates { get; set; }
    public Priority Priority { get; set; }
    public Progress Progress { get; set; }
    public List<User> TaskUsers = new List<User>();
    public Guid ProjectId { get; set; }
    
    [ForeignKey("ProjectId")]
    public virtual Project Project { get; set; }
    public virtual List<TaskFile> UploadedFiles { get; set; } = new List<TaskFile>();
}
