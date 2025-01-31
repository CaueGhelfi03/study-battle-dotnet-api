using TaskSystem.Domain.DTOs.UserDTO;

namespace TaskSystem.Services.Interfaces.User
{
    public interface IUserService
    {
        Task<UserResponseDTO> AddUserAsync(UserRequestDTO user);
        Task<UserResponseDTO> UpdateUserAsync(UserRequestDTO user, Guid Id);
        Task<UserResponseDTO> GetByIdAsync(Guid Id);
        Task<IEnumerable<UserResponseDTO>> GetAllAsync();
        Task<bool> DeleteUserAsync(Guid Id);
    }
}
