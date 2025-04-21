using StudyBattle.API.Services.Interfaces.Generic;
using TaskSystem.Core.Domain.DTOs.ChallengeUserDTO;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;

namespace StudyBattle.API.Services.Interfaces.ChallengeUser
{
    public interface IChallengeUserService : IGenericService<Guid,ChallengeUserProgressEntity, ChallengeUserCreateDTO, ChallengeUserUpdateDTO, UserProgressResponseDTO>
    {

        public Task<UserProgressResponseDTO> AddUserToChallenge (ChallengeUserCreateDTO challengeUserCreateDTO);
        public Task<ChallengeUserResponseDTO> GetChallengeWithUserProgress(Guid ChallengeId);
        public Task<UserProgressResponseDTO> GetUserProgress(Guid UserId);

    }
}
