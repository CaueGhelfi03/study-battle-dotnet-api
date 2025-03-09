using TaskSystem.Domain.DTOs.UserDTO;
using TaskSystem.core.Domain.DTOs.UserDTO;
using TaskSystem.Domain.Models.User;
using StudyBattle.api.Services.Interfaces.Generic;

namespace TaskSystem.Services.Interfaces.User
{
    public interface  IUserService : IGenericService<UserEntity,UserCreateDTO,UserUpdateDTO,UserResponseDTO>
    {
        Task<UserResponseDTO> AddUserAsync(UserCreateDTO user);
        Task<bool> ExistsEmailAsync(string email);
    }
}

