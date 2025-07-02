using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using TaskSystem.Core.Domain.DTOs.UserTaskDTO;
using TaskSystem.Core.Domain.Entities.UserTaskCompletion;
using TaskSystem.Core.Domain.Models.User;

namespace StudyBattle.API.Repostories.Interfaces.UserTaskRepository
{
    public interface IUserTaskRepository : IGenericRepository<Guid, UserTaskCompletionEntity>
    {
        public Task<List<UserTaskCompletionEntity>> GetAllTaskCompletationByUser(Guid UserId);

    }
}
