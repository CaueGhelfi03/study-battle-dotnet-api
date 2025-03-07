using TaskSystem.Domain.DTOs.UserDTO;
using TaskSystem.core.Domain.DTOs.UserDTO;
using TaskSystem.Domain.Models.User;
using StudyBattle.api.Services.Interfaces.Generic;

namespace TaskSystem.Services.Interfaces.User
{
    public interface  IUserService : IGenericService<UserEntity,UserRequestDTO,UserUpdateDTO,UserResponseDTO>
    {
        Task<UserResponseDTO> AddUserAsync(UserRequestDTO user);
        Task<bool> ExistsEmailAsync(string email);
    }
}

