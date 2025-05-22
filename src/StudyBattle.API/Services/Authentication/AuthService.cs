using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StudyBattle.API.Interfaces.User;
using StudyBattle.API.Services.Interfaces.IAuthService;
using StudyBattle.API.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskSystem.Core.Domain.DTOs.AuthDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;

namespace StudyBattle.API.Services.Authentication
{
    public class AuthService(IConfiguration _configuration, IUserService _userService, IMapper _mapper) : IAuthService
    {
        public async Task<AuthResponseDTO> Authenticate(LoginDTO loginDTO)
        {
            if (loginDTO == null) throw new ArgumentNullException(nameof(loginDTO));

            var user = await _userService.GetByEmail(loginDTO.Email);

            var claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Email, loginDTO.Email)
            };

            var key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new ArgumentNullException("Jwt not found")));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var jwtToken = token as JwtSecurityToken;

            var userIdClaim = jwtToken.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "nameid");

            var emailClaim = jwtToken.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Email || c.Type == "email");

            var userId = userIdClaim?.Value ?? throw new ArgumentNullException("User ID not found");
            var email = emailClaim?.Value ?? throw new ArgumentNullException("Email not found");

            var response = new AuthResponseDTO
            {
                Email = email,
                UserId = userId,
                Token = tokenHandler.WriteToken(jwtToken)
            };
            return response;
        }

    }
}
