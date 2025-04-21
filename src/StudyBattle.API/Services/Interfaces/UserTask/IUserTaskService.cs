using StudyBattle.API.Services.Interfaces.Generic;
using TaskSystem.Core.Domain.DTOs.UserTaskCompletationDTO;
using TaskSystem.Core.Domain.DTOs.UserTaskDTO;
using TaskSystem.Core.Domain.Entities.UserTaskCompletion;

namespace StudyBattle.API.Services.Interfaces.UserTaskCompletation
{
    public interface IUserTaskService : IGenericService<Guid, UserTaskCompletionEntity, UserTaskCreateDTO, UserTaskUpdateDTO, UserTaskResponseDTO>
    {
        public Task<UserAllTasksDTO> GetAllTaskCompletationByUser(Guid UserId);
        public Task<UserTaskResponseDTO> AddUserCompletation(UserTaskCreateDTO UserTask);
    }
}
