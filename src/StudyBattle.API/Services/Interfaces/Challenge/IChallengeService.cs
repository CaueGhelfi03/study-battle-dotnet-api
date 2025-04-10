using StudyBattle.API.Services.Interfaces.Generic;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Entities.Challenge;

namespace StudyBattle.API.Services.Interfaces.Challenge
{
    public interface IChallengeService : IGenericService<Guid,ChallengeEntity, ChallengeCreateDTO, ChallengeUpdateDTO, ChallengeResponseDTO>
    {
        public Task<ICollection<ChallengeUsersResponseDTO>> GetAllChallengesActive();
        public Task<ChallengeResponseDTO> CreateChallengeAsync(ChallengeCreateDTO challenge);
        public Task<ChallengeTaskResponseDTO> GetChallengeWithTasksById(Guid ChallengeId);
    }
}
