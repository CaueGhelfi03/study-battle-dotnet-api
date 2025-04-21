using Microsoft.AspNetCore.Mvc;
using StudyBattle.API.Services.Interfaces.ChallengeUser;
using TaskSystem.Core.Domain.DTOs.ChallengeUserDTO;

namespace StudyBattle.API.Controllers.ChallengeUserProgress
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ChallengeUserController(IChallengeUserService service) : Controller
    {

        [HttpPost]
        public async Task<ActionResult<UserProgressResponseDTO>> AddChallengeUser ([FromBody] ChallengeUserCreateDTO challengeUserCreateDTO)
        {
                var challengeUser = await service.AddUserToChallenge(challengeUserCreateDTO);

                return challengeUser;
        }

        [HttpGet]
        public async Task<ActionResult<ChallengeUserResponseDTO>> GetChallengeWithUserProgress([FromQuery] Guid ChallengeId)
        {
            var challenge = await service.GetChallengeWithUserProgress(ChallengeId);

            return challenge;
        }

        [HttpGet]
        [Route("/challenge-progress/user/")]
        public async Task<ActionResult<UserProgressResponseDTO>> GetUserProgress([FromQuery] Guid UserId)
        {
            var userId = await service.GetUserProgress(UserId);

            return userId;
        }

    }
}
