using Core.Models;

namespace BLL.Abstractions.Interfaces;

public interface IUserProjectService : IGenericService<UserProject>
{
    Task AddUserAndProject(User stakeHolder, Project project);

    Task<UserProject> GetUserAndProject(Guid projectId);
}