using StudyBattle.api.Services.Interfaces.Generic;
using StudyBattle.core.Domain.DTOs.ChallengeDTO;
using StudyBattle.core.Domain.Entities.Challenge;
using TaskSystem.core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Domain.DTOs.UserDTO;

namespace StudyBattle.api.Services.Interfaces.Challenge
{
    public interface IChallengeService : IGenericService<ChallengeEntity, ChallengeCreateDTO,ChallengeUpdateDTO,ChallengeResponseDTO>
    {

        Task<ChallengeResponseDTO> GetAllChallengeActives();
        Task<ChallengeResponseDTO> AddUserOnChallenge(UserResponseDTO user);

        
        //Participar de um desafio (POST)




    }
}
