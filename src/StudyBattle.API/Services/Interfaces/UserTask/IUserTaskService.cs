using StudyBattle.API.Services.Interfaces.Generic;
using TaskSystem.Core.Domain.DTOs.ChallengeUserDTO;
using TaskSystem.Core.Domain.DTOs.TaskDTO;
using TaskSystem.Core.Domain.DTOs.UserTaskCompletationDTO;
using TaskSystem.Core.Domain.DTOs.UserTaskDTO;
using TaskSystem.Core.Domain.Entities.UserTaskCompletion;
using TaskSystem.Core.Domain.Enums.TaskComplexity;

namespace StudyBattle.API.Services.Interfaces.UserTaskCompletation
{
    public interface IUserTaskService : IGenericService<Guid, UserTaskCompletionEntity, UserTaskCreateDTO, UserTaskUpdateDTO, UserTaskResponseDTO>
    {
        public Task<UserAllTasksDTO> GetAllTaskCompletationByUser(Guid UserId);
        public Task<UserTaskResponseDTO> AddUserCompletation(UserTaskCreateDTO UserTask);
        public Task<TaskResponseDTO> GetNextTask(UserTaskCreateDTO userTask);
        public Task<UserProgressResponseDTO> GetUserProgress(Guid userId, Guid challengeId);
        public int CalculateScore(TaskComplexityEnum complexity, int streakCount);
    }
}
