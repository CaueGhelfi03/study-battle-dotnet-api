using AutoMapper;
using StudyBattle.API.Interfaces.User;
using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using StudyBattle.API.Repostories.Interfaces.UserTaskRepository;
using StudyBattle.API.Repostories.Task;
using StudyBattle.API.Services.Generic;
using StudyBattle.API.Services.Interfaces.Challenge;
using StudyBattle.API.Services.Interfaces.ChallengeUser;
using StudyBattle.API.Services.Interfaces.Generic;
using StudyBattle.API.Services.Interfaces.Task;
using StudyBattle.API.Services.Interfaces.TaskScoreCount;
using StudyBattle.API.Services.Interfaces.UserTaskCompletation;
using TaskSystem.Core.Domain.DTOs.ChallengeUserDTO;
using TaskSystem.Core.Domain.DTOs.UserTaskCompletationDTO;
using TaskSystem.Core.Domain.DTOs.UserTaskDTO;
using TaskSystem.Core.Domain.Entities.Challenge;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;
using TaskSystem.Core.Domain.Entities.UserTaskCompletion;
using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Enums.TaskComplexity;
using TaskSystem.Core.Domain.Models.Task;
using TaskSystem.Core.Domain.Models.User;
using TaskSystem.Repostories.Interfaces.TaskRepository;
using TaskSystem.Repostories.Interfaces.UserRepository;

namespace StudyBattle.API.Services.UserTaskCompletation
{
    public class UserTaskService : GenericService<Guid, UserTaskCompletionEntity, UserTaskCreateDTO, UserTaskUpdateDTO, UserTaskResponseDTO>, IUserTaskService
    {

        private readonly IUserService _userService;
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IChallengeService _challengeService;
        private readonly IChallengeUserService _challengeUser;
        private readonly ITaskScoreCountService _scoreCount;



        public UserTaskService(
            IGenericRepository<Guid, UserTaskCompletionEntity> repository,
            IMapper mapper,
            IUserService userService,
            ITaskService taskService,
            ITaskRepository taskRepository,
            IUserTaskRepository userTaskRepository,
            IChallengeService challengeService,
            IChallengeUserService challengeUser,
            ITaskScoreCountService scoreCount
        ) : base(repository, mapper)
        {
            _userService = userService;
            _taskService = taskService;
            _taskRepository = taskRepository;
            _userTaskRepository = userTaskRepository;
            _challengeService = challengeService;
            _challengeUser = challengeUser;
            _scoreCount = scoreCount;
        }

        public async Task<UserTaskResponseDTO> AddUserCompletation(UserTaskCreateDTO UserTask)
        {
            if (UserTask == null) throw new ArgumentNullException(nameof(UserTask));

            var user = await _userService.GetByIdAsync(UserTask.UserId)
                ?? throw new Exception("User not found");

            var task = await _taskService.GetByIdAsync(UserTask.TaskId)
                ?? throw new Exception("Task not found");

            var challengeWithProgress = await _challengeUser.GetChallengeWithUserProgress(task.ChallengeId);

            var challengeUserDTO = _mapper.Map<ChallengeUserResponseDTO>(challengeWithProgress);

            var currentUserProgress = challengeUserDTO.UserProgress
                .FirstOrDefault(up => up.UserId == user.Id)
                ?? throw new Exception("User progress not found for this challenge");

            var completedTasks = await _userTaskRepository.GetAllTaskCompletationByUser(UserTask.UserId);
            var allTasks = await _taskRepository.GetTasksByChallengeIdAsync(task.ChallengeId);

            var nextTask = allTasks
                .OrderBy(t => t.Order)
                .FirstOrDefault(t => !completedTasks.Any(ct => ct.TaskId == t.Id));

            if (nextTask == null || nextTask.Id != task.Id)
                throw new Exception("This task cannot be completed yet. Please complete all previous tasks first.");

            var score = _scoreCount.GetScore(task.Complexity, currentUserProgress.StreakCount);

            var newUserTask = new UserTaskCompletionEntity
            {
                UserId = user.Id,
                TaskId = task.Id,
                CompletionDate = DateTime.UtcNow,
                Status = StatusEnum.Completed,
                Score = score
            };

            await _userTaskRepository.CreateAsync(newUserTask);

            return _mapper.Map<UserTaskResponseDTO>(newUserTask);
        }

        public async Task<UserAllTasksDTO> GetAllTaskCompletationByUser(Guid UserId)
        {
            var userTasks = await _userTaskRepository.GetAllTaskCompletationByUser(UserId) ?? null;

            return _mapper.Map<UserAllTasksDTO>(userTasks);
        }
    }
}
