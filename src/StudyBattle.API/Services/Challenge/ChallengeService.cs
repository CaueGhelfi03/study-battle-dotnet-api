using AutoMapper;
using StudyBattle.API.Repostories.Interfaces.ChallengeRepository;
using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using StudyBattle.API.Services.Generic;
using StudyBattle.API.Services.Interfaces.Challenge;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Entities.Challenge;
using StudyBattle.API.Interfaces.ICommon;
using TaskSystem.Repostories.Interfaces.UserRepository;
using System.Runtime.InteropServices;
using TaskSystem.Core.Domain.Enums.Status;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;

namespace StudyBattle.API.Services.Challenge
{
    public class ChallengeService : GenericService<Guid,ChallengeEntity, ChallengeCreateDTO, ChallengeUpdateDTO, ChallengeResponseDTO>, IChallengeService
    {
        private readonly IChallengeRepository _challengeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ChallengeService(
            IGenericRepository<Guid,ChallengeEntity> repository, 
            IMapper mapper,
            IChallengeRepository challengeRepository,
            IUserRepository userRepository,
            ICommonService commonService
        ) : base(repository, mapper)
        {
            _challengeRepository = challengeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<ICollection<ChallengeUsersResponseDTO>> GetAllChallengesActive()
        {
            try
            {
                var challenge = await _challengeRepository.GetAllAsync();

                challenge = challenge.Where(c => c.status == StatusEnum.InProgress || c.status == StatusEnum.Pending);

                var challengeMapped = _mapper.Map<ICollection<ChallengeUsersResponseDTO>>(challenge);

                return challengeMapped.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ChallengeResponseDTO> CreateChallengeAsync(ChallengeCreateDTO challenge)
        {
            if (challenge == null) throw new ArgumentNullException(nameof(challenge));
            try
            {
                var newChallenge = new ChallengeEntity
                {
                    Name = challenge.Name,
                    Description = challenge.Description,
                    DurationDays = challenge.DurationDays,
                    Start_Date = challenge.Start_Date,
                    End_Date = challenge.End_Date,
                    status = challenge.status,
                    ChallengeComplexity = challenge.ChallengeComplexity,
                };

                await _challengeRepository.CreateChallengeAsync(newChallenge);
                var mappedChallenge = _mapper.Map<ChallengeResponseDTO>(newChallenge);
                return mappedChallenge;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ChallengeTaskResponseDTO> GetChallengeWithTasksById(Guid ChallengeId)
        {
            if (ChallengeId == Guid.Empty) throw new ArgumentNullException(nameof(ChallengeId));
            try
            {
                var challenge = await _challengeRepository.GetChallengeWithTasksById(ChallengeId);

                if (challenge == null) return null;

                return _mapper.Map<ChallengeTaskResponseDTO>(challenge);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
