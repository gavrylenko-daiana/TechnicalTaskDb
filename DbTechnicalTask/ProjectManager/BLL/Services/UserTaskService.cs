using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services;

public class UserTaskService : GenericService<UserTask>, IUserTaskService
{
    public UserTaskService(IRepository<UserTask> repository) : base(repository)
    {
    }
}