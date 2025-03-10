using TaskSystem.Core.Domain.Models.Task;

namespace TaskSystem.Repostories.Interfaces.TaskRepository
{
    public interface ITaskRepository
    {
        Task<List<TaskEntity>> GetAll();
        Task<TaskEntity> GetById(Guid id);
        Task<TaskEntity> AddTask(TaskEntity task);
        Task<TaskEntity> UpdateTask(TaskEntity task, Guid id);
        Task<bool> DeleteTask(Guid id);

    }
}
