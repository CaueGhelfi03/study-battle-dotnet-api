using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Models.User;
using TaskSystem.Core.Utils.Extensions;
using TaskSystem.Services.Interfaces.User;
using TaskSystem.Services.UserService;

namespace SistemaDeTarefas.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService) : Controller
    {
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] UserRequestDTO userRequest)
        {
            try
            {
                var createdUser = await _userService.AddUserAsync(userRequest);
                return Created();
            }catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllAsync()
        {
            try
            {
                var users = await _userService.GetAllAsync();

                if (users is null || !users.SafeAny())
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<UserResponseDTO>> UpdateAsync([FromRoute] Guid id, [FromBody] UserUpdateDTO userRequest)
        {
            try
            {
                var user = await _userService.UpdateAsync(id,userRequest);
                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
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
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
