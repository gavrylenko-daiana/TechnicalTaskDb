using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services;

public class UserProjectService : GenericService<UserProject>, IUserProjectService
{
    public UserProjectService(IRepository<UserProject> repository) : base(repository)
    {
    }

    public async Task AddUserAndProject(User stakeHolder, Project project)
    {
        if (stakeHolder == null) throw new ArgumentNullException(nameof(stakeHolder));
        if (project == null) throw new ArgumentNullException(nameof(project));

        try
        {
            await Add(new UserProject
            {
                User = stakeHolder,
                Project = project,
                UserId = stakeHolder.Id,
                ProjectId = project.Id
            });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<UserProject> GetUserAndProject(Guid projectId)
    {
        var userProject = await GetByPredicate(up => up.ProjectId == projectId);
        return userProject;
    }
}