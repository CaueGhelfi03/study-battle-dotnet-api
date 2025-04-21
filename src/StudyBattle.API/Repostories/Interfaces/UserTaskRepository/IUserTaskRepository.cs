using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using TaskSystem.Core.Domain.DTOs.UserTaskDTO;
using TaskSystem.Core.Domain.Entities.UserTaskCompletion;

namespace StudyBattle.API.Repostories.Interfaces.UserTaskRepository
{
    public interface IUserTaskRepository : IGenericRepository<Guid, UserTaskCompletionEntity>
    {
        public Task<ICollection<UserTaskCompletionEntity>> GetAllTaskCompletationByUser(Guid UserId);

    }
}
