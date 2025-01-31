using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using TaskSystem.Domain.DTOs.UserDTO;
using TaskSystem.Domain.Models.User;
using TaskSystem.Services.Interfaces.User;
using TaskSystem.Services.UserService;

namespace SistemaDeTarefas.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService) : Controller
    {
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserRequestDTO userRequest)
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
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                if (users == null || users.Any()!)
                {
                    return NoContent();
                }; // Return a list of all users with HTTP 200 OK
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
