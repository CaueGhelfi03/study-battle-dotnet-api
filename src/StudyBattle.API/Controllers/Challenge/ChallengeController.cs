using Microsoft.AspNetCore.Mvc;
using StudyBattle.API.Services.Interfaces.Challenge;
using System.ComponentModel.DataAnnotations;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.DTOs.ChallengeUserDTO;
using TaskSystem.Core.Utils.Extensions;

namespace StudyBattle.API.Controllers.Challenge
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController(IChallengeService service) : Controller
    {
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] ChallengeCreateDTO challengeCreateDTO)
        {
                var createdChallenge = await service.CreateAsync(challengeCreateDTO);
                return Ok(createdChallenge);
        }

        [HttpPatch]
        public async Task<ActionResult<ChallengeResponseDTO>> UpdateChallenge([Required][FromQuery] Guid Id, [FromBody] ChallengeUpdateDTO challengeUpdateDTO)
        {
                var challengeUpdated = await service.UpdateAsync(Id, challengeUpdateDTO);
                return Ok(challengeUpdated);
        }

        [Route("{ChallengeId}")]
        [HttpDelete]
        public async Task<ActionResult<bool?>> DeleteChallenge([Required][FromRoute] Guid ChallengeId)
        {
                await service.DeleteAsync(ChallengeId);
                return NoContent();
        }


        [Route("active")]
        [HttpGet]
        public async Task<ActionResult<ICollection<UserProgressResponseDTO>>> GetAllActiveChallenge()
        {
                var challenges = await service.GetAllChallengesActive();
                if (!challenges.SafeAny()) return NoContent();

                return Ok(challenges);
        }

        [Route("{ChallengeId}/tasks")]
        [HttpGet]
        public async Task<ActionResult<ChallengeTaskResponseDTO>> GetChallengeWithTasksById([Required][FromRoute] Guid ChallengeId)
        {
                var challenges = await service.GetChallengeWithTasksById(ChallengeId);

                return Ok(challenges);
        }

        [Route("challenge-by-subject")]
        [HttpGet]
        public async Task<ActionResult<ChallengeResponseDTO>> GetChallengeBySubject([Required][FromQuery] string subject)
        {
            var challenges = await service.GetAllChallengeBySubject(subject);
            return Ok(challenges);
        }
    }
}
