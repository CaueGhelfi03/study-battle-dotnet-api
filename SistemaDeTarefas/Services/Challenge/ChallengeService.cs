using AutoMapper;
using StudyBattle.api.Services.Generic;
using StudyBattle.api.Services.Interfaces.Challenge;
using StudyBattle.api.Services.Interfaces.Generic;
using StudyBattle.core.Domain.DTOs.ChallengeDTO;
using StudyBattle.core.Domain.Entities.Challenge;
using TaskSystem.core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Domain.DTOs.UserDTO;

namespace StudyBattle.api.Services.Challenge
{
    public class ChallengeService(IMapper _mapper, ) : GenericService<ChallengeEntity, ChallengeCreateDTO, ChallengeUpdateDTO, ChallengeResponseDTO>, IChallengeService
    {
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
