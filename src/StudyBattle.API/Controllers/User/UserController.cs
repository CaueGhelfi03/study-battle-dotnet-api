using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Utils.Extensions;
using StudyBattle.API.Interfaces.User;

namespace SistemaDeTarefas.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService) : Controller
    {
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] UserCreateDTO userRequest)
        {
            try
            {
                var createdUser = await _userService.AddUserAsync(userRequest);

                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPatch]
        public async Task<ActionResult<UserResponseDTO>> UpdateAsync([Required][FromQuery] Guid id, [FromBody] UserUpdateDTO userRequest)
        {
            try
            {
                var user = await _userService.UpdateAsync(id, userRequest);

                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }


        [Route("/api/[controller]/{id}")]
        [HttpDelete]
        public async Task<ActionResult<bool?>> DeleteAsync([FromRoute] Guid id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllAsync()
        {
            try
            {
                var users = await _userService.GetAllAsync();

                if (!users.SafeAny())
                    return NoContent();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpGet]
        public async Task<ActionResult<UserResponseDTO>> GetByIdAsync([FromRoute] Guid id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
