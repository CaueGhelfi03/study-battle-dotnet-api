using Microsoft.AspNetCore.Mvc;
using StudyBattle.API.Services.Interfaces.Challenge;
using System.ComponentModel.DataAnnotations;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
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
            try
            {
                var createdChallenge = await service.CreateAsync(challengeCreateDTO);
                return Ok(createdChallenge);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<ChallengeResponseDTO>> UpdateChallenge([Required][FromQuery] Guid Id, [FromBody] ChallengeUpdateDTO challengeUpdateDTO)
        {
            try
            {
                var challengeUpdated = await service.UpdateAsync(Id, challengeUpdateDTO);
                return Ok(challengeUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [Route("{ChallengeId}")]
        [HttpDelete]
        public async Task<ActionResult<bool?>> DeleteChallenge([Required][FromRoute] Guid ChallengeId)
        {
            try
            {
                await service.DeleteAsync(ChallengeId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChallengeResponseDTO>>> GetAllChallenges()
        {
            try
            {
                var challenges = await service.GetAllAsync();
                if (!challenges.SafeAny()) return NoContent();

                return Ok(challenges);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("active")]
        [HttpGet]
        public async Task<ActionResult<ICollection<ChallengeUsersResponseDTO>>> GetAllActiveChallenge()
        {
            try
            {
                var challenges = await service.GetAllChallengesActive();

                return Ok(challenges);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [Route("{ChallengeId}/tasks")]
        [HttpGet]
        public async Task<ActionResult<ChallengeTaskResponseDTO>> GetChallengeWithTasksById([Required][FromRoute] Guid ChallengeId)
        {
            try
            {
                var challenges = await service.GetChallengeWithTasksById(ChallengeId);

                return Ok(challenges);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
