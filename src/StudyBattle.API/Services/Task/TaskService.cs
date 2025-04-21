using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using StudyBattle.API.Repostories.Interfaces.ChallengeRepository;
using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using StudyBattle.API.Services.Generic;
using StudyBattle.API.Services.Interfaces.Task;
using System.Security;
using TaskSystem.Core.Domain.DTOs.TaskDTO;
using TaskSystem.Core.Domain.Entities.UserTaskCompletion;
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


        public async Task<TaskResponseDTO> AddTaskToChallengeAsync(TaskCreateDTO taskDTO,Guid ChallengeId)
        {
            try
            {
                var challenge = await _challengeRepository.GetByIdAsync(ChallengeId) ?? throw new Exception("Challenge not found");

                var task = new TaskEntity
                {
                    Id = Guid.NewGuid(),
                    Challenge = challenge,
                    TaskName = taskDTO.TaskName,
                    Description = taskDTO.Description,
                    CreatedAt = taskDTO.CreatedAt,
                    Complexity = taskDTO.Complexity,
                    Status = taskDTO.Status,
                };

                await _repository.CreateAsync(task);

                challenge.Tasks ??= [];
                challenge.Tasks.Add(task);

                await _challengeRepository.UpdateAsync(challenge.Id, challenge);

                return _mapper.Map<TaskResponseDTO>(task);

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
                var ordered = tasks.OrderBy(x => x.Order);
                var mappedTasks = _mapper.Map<ICollection<TaskResponseDTO>>(ordered);

                return mappedTasks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}
