using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Models.User;
using StudyBattle.API.Services.Interfaces.Generic;

namespace TaskSystem.Services.Interfaces.User
{
    public interface  IUserService : IGenericService<UserEntity,UserRequestDTO,UserUpdateDTO,UserResponseDTO>
    {
        Task<UserResponseDTO> AddUserAsync(UserRequestDTO user);
        Task<bool> ExistsEmailAsync(string email);
    }
}

