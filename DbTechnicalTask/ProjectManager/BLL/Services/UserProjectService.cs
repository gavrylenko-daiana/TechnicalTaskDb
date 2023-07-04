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
        if (projectId == Guid.Empty) throw new Exception(nameof(projectId));
        
        var userProject = await GetByPredicate(up => up.ProjectId == projectId);
        
        return userProject;
    }

    public async Task<bool> IsUserInProject(Guid userId, Guid projectId)
    {
        if (userId == Guid.Empty) throw new Exception(nameof(userId));
        if (projectId == Guid.Empty) throw new Exception(nameof(projectId));

        try
        {
            var userProject = await GetUserProjectByUserIdAndProjectId(userId, projectId);
        
            return userProject != null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    
    public async Task<UserProject> GetUserProjectByUserIdAndProjectId(Guid userId, Guid projectId)
    {
        if (userId == Guid.Empty) throw new Exception(nameof(userId));
        if (projectId == Guid.Empty) throw new Exception(nameof(projectId));

        try
        {
            var userProject = await GetAll();
            var getUserProject = userProject.FirstOrDefault(up => up.UserId == userId && up.ProjectId == projectId);

            return getUserProject!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}