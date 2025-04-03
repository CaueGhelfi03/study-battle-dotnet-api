using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using StudyBattle.API.Repostories.Interfaces.ChallengeRepository;
using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using StudyBattle.API.Services.Generic;
using StudyBattle.API.Services.Interfaces.Task;
using TaskSystem.Core.Domain.DTOs.TaskDTO;
using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Models.Task;
using TaskSystem.Repostories.Interfaces.TaskRepository;
using TaskSystem.Repostories.Interfaces.UserRepository;

namespace StudyBattle.API.Services.Task
{
    public class TaskService : GenericService<Guid, TaskEntity, TaskCreateDTO, TaskUpdateDTO, TaskResponseDTO>, ITaskService
    {

        private readonly ITaskRepository _taskRepository;
        private readonly IChallengeRepository _challengeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public TaskService(
            IGenericRepository<Guid, TaskEntity> repository,
            ITaskRepository taskRepository,
            IChallengeRepository challengeRepository,
            IUserRepository userRepository,
            IMapper mapper
            ) : base(repository, mapper)
        {
            _taskRepository = taskRepository;
            _challengeRepository = challengeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<TaskResponseDTO> AddTaskToChallengeAsync(TaskCreateDTO taskDTO)
        {
            try
            {
                var challenge = await _challengeRepository.GetByIdAsync(taskDTO.ChallengeId) ?? throw new Exception("Challenge not found");
                var user = await _userRepository.GetByIdAsync(taskDTO.UserId) ?? throw new Exception("User not found");

                var task = new TaskEntity
                {
                    ChallengeId = taskDTO.ChallengeId,
                    UserId = taskDTO.UserId,
                    TaskName = taskDTO.TaskName,
                    Description = taskDTO.Description,
                    CreatedAt = taskDTO.CreatedAt,
                    Status = taskDTO.Status,
                };

                await _repository.CreateAsync(task);
                var mappedTask = _mapper.Map<TaskResponseDTO>(task);
                return mappedTask;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<StatusEnum> CompleteTaskAsync(Guid TaskId, Guid UserId)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(UserId) ?? throw new Exception("User not found");
                var task = await _repository.GetByIdAsync(TaskId) ?? throw new Exception("Task not found");

                if (task.UserId != UserId) throw new Exception("User is not authorized to complete this task.");

                task.Status = StatusEnum.Completed;
                //task.completedAt = DateTime.UtcNow;

                await _repository.UpdateAsync(user.Id, task);
                return task.Status;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<TaskResponseDTO>> GetTaskByChallengeId(Guid ChallengeId)
        {
            try
            {
                var challenge = await _repository.GetByIdAsync(ChallengeId) ?? throw new Exception("Challenge not found");

                ICollection<TaskEntity> tasks = await _taskRepository.GetTasksByChallengeIdAsync(challenge.ChallengeId) ?? throw new Exception("");

                var mappedTasks = _mapper.Map<ICollection<TaskResponseDTO>>(tasks);

                return mappedTasks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<TaskResponseDTO>> GetTasksByUserIdAsync(Guid UserId)
        {
            try
            {
                var user = await _repository.GetByIdAsync(UserId) ?? throw new Exception("User not found");

                ICollection<TaskEntity> tasks = await _taskRepository.GetTasksByUserIdAsync(user.Id) ?? throw new Exception("");

                var mappedTasks = _mapper.Map<ICollection<TaskResponseDTO>>(tasks);

                return mappedTasks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
