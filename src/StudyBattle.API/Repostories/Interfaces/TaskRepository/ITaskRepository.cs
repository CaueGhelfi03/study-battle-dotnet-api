using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using TaskSystem.Core.Domain.Models.Task;

namespace TaskSystem.Repostories.Interfaces.TaskRepository
{
    public interface ITaskRepository : IGenericRepository<Guid, TaskEntity> 
    {
        Task<ICollection<TaskEntity>> GetTasksByChallengeIdAsync(Guid challengeId);
    }
}
