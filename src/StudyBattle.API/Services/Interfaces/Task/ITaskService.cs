﻿using StudyBattle.API.Services.Interfaces.Generic;
using TaskSystem.Core.Domain.DTOs.TaskDTO;
using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Models.Task;

namespace StudyBattle.API.Services.Interfaces.Task
{
    public interface ITaskService : IGenericService<Guid, TaskEntity, TaskCreateDTO,TaskUpdateDTO,TaskResponseDTO>
    {
        Task<TaskResponseDTO> AddTaskToChallengeAsync(TaskCreateDTO taskDTO, Guid ChallengeId);
        Task<ICollection<TaskResponseDTO>> GetTaskByChallengeId(Guid ChallengeId);
    }
}
