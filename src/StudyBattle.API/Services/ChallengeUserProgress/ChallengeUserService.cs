using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using StudyBattle.API.Interfaces.User;
using StudyBattle.API.Repostories.Challenge;
using StudyBattle.API.Repostories.ChallengeUserProgress;
using StudyBattle.API.Repostories.Interfaces.ChallengeRepository;
using StudyBattle.API.Repostories.Interfaces.ChallengeUserRepository;
using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using StudyBattle.API.Services.Generic;
using StudyBattle.API.Services.Interfaces.Challenge;
using StudyBattle.API.Services.Interfaces.ChallengeUser;
using TaskSystem.Core.Domain.DTOs.ChallengeUserDTO;
using TaskSystem.Core.Domain.Entities.Challenge;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;
using TaskSystem.Core.Domain.Models.User;

namespace StudyBattle.API.Services.ChallengeUserProgress
{
    
    public class ChallengeUserService : GenericService<Guid, ChallengeUserProgressEntity, ChallengeUserCreateDTO, ChallengeUserUpdateDTO, UserProgressResponseDTO>, IChallengeUserService
    {
        private readonly IMapper _mapper;
        private readonly IChallengeService _challengeService;
        private readonly IChallengeUserRepository _challengeUserRepository;
        private readonly IUserService _userService;
        private readonly IChallengeRepository _challengeRepository;

        public ChallengeUserService(
            IMapper mapper,
            IGenericRepository<Guid, ChallengeUserProgressEntity> repository,
            IChallengeService challengeService,
            IChallengeUserRepository challengeUserRepository,
            IChallengeRepository challengeRepository,
            IUserService userService)
            : base(repository, mapper)
        {
            _mapper = mapper;
            _challengeService = challengeService;
            _userService = userService;
            _challengeUserRepository = challengeUserRepository;
            _challengeRepository = challengeRepository;
        }

        public async Task<UserProgressResponseDTO> AddUserToChallenge(ChallengeUserCreateDTO challengeUserCreateDTO)
        {
            if (challengeUserCreateDTO == null) throw new ArgumentNullException(nameof(challengeUserCreateDTO));

            var challenge = await _challengeService.GetChallengeWithTasksById(challengeUserCreateDTO.ChallengeId)
                   ?? throw new Exception("Challenge not found");

            var user = await _userService.GetByIdAsync(challengeUserCreateDTO.UserId)
                   ?? throw new Exception("User not found");

            var existingProgress = await _challengeUserRepository.GetByUserAndChallengeId(challengeUserCreateDTO.UserId, challengeUserCreateDTO.ChallengeId);

            if (existingProgress != null)
                throw new Exception("User is already registered in this challenge.");

            var challengeUserEntity = _mapper.Map<ChallengeUserProgressEntity>(challengeUserCreateDTO);
            challengeUserEntity.StartedAt = DateTime.UtcNow;
            challengeUserEntity.LastActiveDate = DateTime.UtcNow;
            challengeUserEntity.StreakCount = 100;

            var created = await _repository.CreateAsync(challengeUserEntity);

            return _mapper.Map<UserProgressResponseDTO>(created);
        }

        public async Task<ChallengeUserResponseDTO> GetChallengeWithUserProgress(Guid ChallengeId)
        {
            var challenge = await _challengeService.GetByIdAsync(ChallengeId);
            if (challenge == null) throw new Exception("challenge not found");

            var progressList = await _challengeUserRepository.GetUserProgressByChallengeId(ChallengeId);

            return new ChallengeUserResponseDTO
            {
               Challenge = challenge,
                UserProgress = _mapper.Map<ICollection<UserProgressResponseDTO>>(progressList)
            };
        }

        public async Task<UserProgressResponseDTO> GetUserProgress(Guid UserId)
        {
            var userProgress = await _challengeUserRepository.GetUserProgressById(UserId);

            var userProgressMapped = _mapper.Map<UserProgressResponseDTO>(userProgress);

            return userProgressMapped;
        }
    }
}
