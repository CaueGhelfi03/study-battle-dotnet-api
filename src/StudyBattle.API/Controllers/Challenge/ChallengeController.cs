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

        [Route("{Id}")]
        [HttpGet]
        public async Task<ActionResult<ChallengeResponseDTO>> GetChallengeById([Required][FromRoute] Guid Id)
        {
            try
            {
                var challenge = await service.GetByIdAsync(Id);

                return Ok(challenge);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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

        [Route("{Id}")]
        [HttpDelete]
        public async Task<ActionResult<bool?>> DeleteChallenge([Required][FromRoute] Guid Id)
        {
            try
            {
                await service.DeleteAsync(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

        }
    }
}
