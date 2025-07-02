using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudyBattle.API.Services.Interfaces.IAuthService;
using TaskSystem.Core.Domain.DTOs.UserDTO;

namespace StudyBattle.API.Controllers.Authentication
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _auth) : ControllerBase
    {

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO request)
        {
            var token = await _auth.Authenticate(request);

            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(token);
        }
    }
}
