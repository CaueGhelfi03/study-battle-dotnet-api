using TaskSystem.Core.Domain.DTOs.AuthDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;

namespace StudyBattle.API.Services.Interfaces.IAuthService
{
    public interface IAuthService
    {
        public Task<AuthResponseDTO> Authenticate(LoginDTO loginDTO);
    }
}
