using StudyBattle.API.Services.Interfaces.Generic;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Entities.Challenge;

namespace StudyBattle.API.Services.Interfaces.Challenge
{
    public interface IChallengeService : IGenericService<ChallengeEntity, ChallengeCreateDTO, ChallengeUpdateDTO, ChallengeResponseDTO>
    {
        Task<ChallengeResponseDTO> AddUserOnChallenge(UserResponseDTO user);
        Task<ChallengeResponseDTO> GetAllChallengeActives();
    }
}
