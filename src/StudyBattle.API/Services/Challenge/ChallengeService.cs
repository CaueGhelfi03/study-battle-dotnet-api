using AutoMapper;
using StudyBattle.API.Repostories.Interfaces.ChallengeRepository;
using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using StudyBattle.API.Services.Generic;
using StudyBattle.API.Services.Interfaces.Challenge;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Entities.Challenge;
using StudyBattle.API.Interfaces.ICommon;

namespace StudyBattle.API.Services.Challenge
{
    public class ChallengeService : GenericService<Guid,ChallengeEntity, ChallengeCreateDTO, ChallengeUpdateDTO, ChallengeResponseDTO>, IChallengeService
    {
        private readonly IChallengeRepository _challengeRepository;
        private readonly IMapper _mapper;

        public ChallengeService(
            IGenericRepository<Guid,ChallengeEntity> repository, 
            IMapper mapper,
            IChallengeRepository challengeRepository,
            ICommonService commonService
        ) : base(repository, mapper)
        {
            _challengeRepository = challengeRepository;
            _mapper = mapper;
        }

        public Task<ChallengeResponseDTO> AddUserOnChallenge(UserResponseDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<ChallengeResponseDTO> GetAllChallengeActives()
        {
            throw new NotImplementedException();
        }
    }
}
